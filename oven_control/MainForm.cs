using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Configuration;
using System.Collections;
using classes;

namespace oven_control
{
  public partial class MainForm : Form
  {
    private const int temp_min = 0;
    private const int temp_max = 300;
    private const int temp_step = 10;

    private static Brush yellow_dotted_brush = new HatchBrush(HatchStyle.Percent50, Color.Yellow, Color.White);
    private static Pen yellowPen = new Pen(yellow_dotted_brush);
    private static Pen greenPen = new Pen(Color.Green);
    private static SolidBrush blackBrush = new SolidBrush(Color.Black);
    private static SolidBrush whiteBrush = new SolidBrush(Color.White);
    private static Font defaultFont = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

    private CommPort cp;
    private int tick_no, r1, r0, pc, pcount;
    private string program_file;
    private int[] temp_results;
    private double u1, A, B;
    private bool heater_on, stab_mode;
    private ArrayList program;
    
    public MainForm(CommPort p, string program_f)
    {
      InitializeComponent();

      try
      {
        r1 = int.Parse(ConfigurationManager.AppSettings["r1"]);
        r0 = int.Parse(ConfigurationManager.AppSettings["r0"]);
        u1 = double.Parse(ConfigurationManager.AppSettings["u1"]);
        A = double.Parse(ConfigurationManager.AppSettings["A"]);
        B = double.Parse(ConfigurationManager.AppSettings["B"]);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
        Close();
        return;
      }

      cp = p;

      cp.ReadTimeout = 100;
      cp.WriteTimeout = 100;

      cp.Write("I");
      string responce = Read();
      if (responce == null)
      {
        MessageBox.Show("Device not respond to identification command.");
        Close();
      }
      else if (responce != "OVENCTL1.0")
      {
        MessageBox.Show("Invalid device identification string:" + responce);
        Close();
      }

      temp_results = new int[1000];
      program = new ArrayList();

      if (program_f != null)
        LoadProgram(program_f);
      else
        program_file = null;

      off();
      get_temp();
    }

    public string Read()
    {
      return Read(-1);
    }

    public string Read(int exp_cnt)
    {
      char[] buffer = new char[100];

      int cnt = 0;

      try
      {
        while (true)
        {
          char c = (char)cp.ReadChar();
          buffer[cnt++] = c;
          if (cnt > 1 &&
              ((c == 'k' && buffer[cnt - 2] == 'O') ||
               (c == 'r' && buffer[cnt - 2] == 'E') ||
               cnt == exp_cnt))
            break;
        }
      }
      catch (TimeoutException)
      {
      }

      if (cnt > 0)
        return new String(buffer, 0, cnt);

      return null;
    }

    private void bnStart_Click(object sender, EventArgs e)
    {
      bnStart.Enabled = false;

      for (int i = 0; i < temp_results.Length; i++)
        temp_results[i] = 0;

      program.Clear();
      pc = 0;
      stab_mode = false;

      try
      {
        CompileProgram();
        tick_no = 0;
        timer.Start();
        bnStop.Enabled = true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bnStart.Enabled = true;
      }
    }

    private void bnStop_Click(object sender, EventArgs e)
    {
      bnStop.Enabled = false;
      timer.Stop();
      off();
      bnStop.Enabled = true;
      bnStart.Enabled = true;
    }

    private void bnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void temp_panel_Paint(object sender, PaintEventArgs e)
    {
      int steps = (temp_max - temp_min) / temp_step;
      float delta = (float)temp_panel.Size.Height / steps;
      float koef = (float)temp_panel.Size.Height / (temp_max - temp_min);

      int temp = temp_max;

      e.Graphics.FillRectangle(whiteBrush, 0, 0, temp_panel.Size.Width, temp_panel.Size.Height);

      for (float i = 0; i <= temp_panel.Size.Height; i += delta)
      {
        e.Graphics.DrawLine(yellowPen, 0, i, temp_panel.Size.Width, i);
        if ((temp % 20) == 0)
          e.Graphics.DrawString(temp.ToString(), defaultFont, blackBrush, 0, i - defaultFont.Height);
        temp -= temp_step;
      }

      for (int i = 1; i < temp_panel.Width; i++)
      {
        if (temp_results[i] == 0)
          break;
        e.Graphics.DrawLine(greenPen, i - 1, get_y_pos(koef, i - 1), i, get_y_pos(koef, i));
      }
    }

    private float get_y_pos(float koef, int i)
    {
      return temp_panel.Size.Height - (temp_results[i] - temp_min) * koef;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      off();
      cp.Close();
    }

    private void LoadProgram(string program_file_name)
    {
      try
      {
        program_code.Text = File.ReadAllText(program_file_name);
        program_file = program_file_name;
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private int get_temp()
    {
      cp.Write("r");
      string code = Read(4);
      double adc_value = int.Parse(code, NumberStyles.HexNumber);
      double u = 2.56 * adc_value / 1024;
      double r = r1 * u / (u1 - u);
      int t = (int)((-r0*A + Math.Sqrt(r0*r0*A*A-4*r0*B*(r0-r)))/(2*r0*B));
      temp_value.Text = t.ToString();
      return t;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      int temp = get_temp();
      tick_no++;
      int time_sec = tick_no % 60;
      int time_min = tick_no / 60;
      time_value.Text = string.Format("{0:D2}:{1:D2}", time_min, time_sec);
      if (tick_no == 1)
        temp_results[0] = temp;
      temp_results[tick_no] = temp;
      temp_panel.Invalidate();

      if (pc >= program.Count)
      {
        bnStop_Click(null, null);
        return;
      }

      int[] v = (int[])program[pc];
      int t = v[0];
      if (!stab_mode)
      {
        if (temp < t)
        {
          if (!heater_on)
            on();
        }
        else if (temp - t <= 5)
        {
          stab_mode = true;
          pcount = v[1];
        }
        else
        {
          if (heater_on)
            off();
        }
      }
      else
      {
        if (temp < t)
        {
          if (!heater_on && t - temp > 5)
            on();
        }
        else
        {
          if (heater_on)
            off();
        }
        pcount--;
        if (pcount == 0)
        {
          pc++;
          stab_mode = false;
        }
      }
    }

    private void CompileProgram()
    {
      string[] lines = program_code.Text.Split('\n');
      int tick = 0;

      foreach (string line in lines)
      {
        string l = line.Replace("\r", "");
        if (line.Length > 0)
        {
          string[] parts = line.Split(':');
          if (parts.Length != 2)
            throw new Exception("Invalid line: " + line);
          int temp = int.Parse(parts[0]);
          int time = int.Parse(parts[1]);
          program.Add(new int[2] { temp, time });
        }
      }
    }

    private void program_code_TextChanged(object sender, EventArgs e)
    {
      bnSaveProgram.Enabled = program_code.TextLength > 0;

      try
      {
        CompileProgram();
      }
      catch
      {
        bnSaveProgram.Enabled = false;
      }
    }

    private void bnLoadProgram_Click(object sender, EventArgs e)
    {
      OpenFileDialog fd = new OpenFileDialog();

      fd.Filter = "Text files (*.txt)|*.txt";

      if (fd.ShowDialog() == DialogResult.OK)
        LoadProgram(fd.FileName);
    }

    private void on()
    {
      cp.Write("e");
      Read(2);
      heater_on = true;
    }

    private void off()
    {
      cp.Write("d");
      Read(2);
      heater_on = false;
    }
  }
}
