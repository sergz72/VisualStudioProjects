using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Configuration;
using classes;

namespace generator_ad9833
{
  public partial class MainForm : Form
  {
    private static CommPort cp;

    private const int B28     = 0x2000;
    private const int HLB     = 0x1000;
    private const int FSELECT = 0x0800;
    private const int PSELECT = 0x0400;
    private const int RESET   = 0x0100;
    private const int SLEEP1  = 0x0080;
    private const int SLEEP12 = 0x0040;
    private const int OPBITEN = 0x0020;
    private const int DIV2    = 0x0008;
    private const int MODE    = 0x0002;
    private const int FREQ_REG0 = 0x4000;
    private const int FREQ_REG1 = 0x8000;

    private const long F_MCLK  = 25000000;

    private static int level_max;
    private static int level_min;

    private static int status_word, freq_word1, freq_word2, f1_value, f2_value, resolution;
    private static Queue<int[]> parameters;
    private static bool stop, afc_active, bxCrossUpdateBlocked, configLoaded = false;

    private Thread controlThread;

    private static float[] AFCResultsBuffer;
    private static Panel panel;

    private static Pen xGridPen, yGridPen, AFCPen, xGridMarkedPen;
    private static SolidBrush backColorBrush, xAxisFontBrush, yAxisFontBrush;
    private static Font yAxisFont, xAxisFont;

    private static Graphics memDC;

    private bool parseColor(string app_setting_name, out Color c)
    {
      string value = ConfigurationManager.AppSettings[app_setting_name];
      if (value != null)
      {
        string[] p = value.Split(',');
        if (p.Length == 3)
        {
          int r, g, b;
          if (int.TryParse(p[0], out r) && int.TryParse(p[1], out g) && int.TryParse(p[2], out b))
          {
            c = Color.FromArgb(r, g, b);
            return true;
          }
        }
        else if (p.Length == 1)
        {
          c = Color.FromName(p[0]);
          return true;
        }
      }

      MessageBox.Show("Incorrect " + app_setting_name + " configuration parameter");
      c = Color.Black;
      return false;
    }

    private Font parseFontParameters(string app_setting_name)
    {
      string value = ConfigurationManager.AppSettings[app_setting_name];
      if (value != null)
      {
        string[] p = value.Split(',');
        if (p.Length == 2)
        {
          float fontSize;
          if (float.TryParse(p[1], out fontSize))
          {
            try
            {
              return new Font(p[0], fontSize, FontStyle.Regular);
            }
            catch {};
          }
        }
      }

      MessageBox.Show("Incorrect " + app_setting_name + " configuration parameter");
      return null;
    }

    public MainForm(CommPort p)
    {
      InitializeComponent();

      cp = p;

      controlThread = null;

      xAxisFont = parseFontParameters("xAxisFont");
      if (xAxisFont == null)
        return;
      yAxisFont = parseFontParameters("xAxisFont");
      if (xAxisFont == null)
        return;

      Color c;

      if (!parseColor("backColor", out c))
        return;
      backColorBrush = new SolidBrush(c);

      if (!parseColor("xGridPenColor", out c))
        return;
      xGridPen = new Pen(c);

      if (!parseColor("xGridMarkedPenColor", out c))
        return;
      xGridMarkedPen = new Pen(c);

      if (!parseColor("yGridPenColor", out c))
        return;
      yGridPen = new Pen(c);

      if (!parseColor("xAxisFontColor", out c))
        return;
      xAxisFontBrush = new SolidBrush(c);

      if (!parseColor("yAxisFontColor", out c))
        return;
      yAxisFontBrush = new SolidBrush(c);

      if (!parseColor("AFCPenColor", out c))
        return;

      string value = ConfigurationManager.AppSettings["AFCPenWidth"];
      float w;
      if (value == null || !float.TryParse(value, out w))
      {
        MessageBox.Show("Incorrect AFCPenWidth configuration parameter");
        return;
      }
      AFCPen = new Pen(c, w);

      value = ConfigurationManager.AppSettings["levelMax"];
      if (value == null || !int.TryParse(value, out level_max))
      {
        MessageBox.Show("Incorrect levelMax configuration parameter");
        return;
      }

      value = ConfigurationManager.AppSettings["levelMin"];
      if (value == null || !int.TryParse(value, out level_min))
      {
        MessageBox.Show("Incorrect levelMin configuration parameter");
        return;
      }

      configLoaded = true;
      F1.Enabled = true;
      modeBox.Enabled = true;

      cp.ReadTimeout = 100;
      cp.WriteTimeout = 100;

      cp.Write("I");
      string responce = Read(8);
      if (responce == null)
      {
        MessageBox.Show("Device not respond to identification command.");
        Close();
      }
      else if (responce != "G98331.0")
      {
        MessageBox.Show("Invalid device identification string:" + responce);
        Close();
      }

      status_word = freq_word2 = f1_value = f2_value = 0;
      freq_word1 = -1;
      parameters = new Queue<int[]>();
      stop = false;

      panel = AFCPanel;

      afc_active = false;

      Sine_CheckedChanged(null, null);

      AFCPanel_Resize(null, null);

      controlThread = new Thread(ControlProc);

      controlThread.Start();

      PortNameLabel.Text = p.PortName;
      PortSpeedLabel.Text = "Baud rate: " + p.BaudRate.ToString();
      PortBitsLabel.Text = "Data bits: " + p.DataBits.ToString();
      PortParityLabel.Text = "Parity: " + p.Parity.ToString();
      PortStopBitsLabel.Text = "Stop bits: " + p.StopBits.ToString();
    }

    private void bnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (controlThread != null)
      {
        stop = true;
        controlThread.Join();
      }
      cp.Close();
    }

    public static string Read()
    {
      return Read(-1);
    }

    public static string Read(int exp_cnt)
    {
      char[] buffer = new char[100];

      int cnt = 0;

      try
      {
        while (true)
        {
          char c = (char)cp.ReadChar();
          buffer[cnt] = c;
          cnt++;
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
      catch (ArgumentException)
      {
      }

      if (cnt > 0)
        return new String(buffer, 0, cnt);

      return null;
    }

    private void STOP_AFC(bool disableUIControls)
    {
      bnStopAFC.Enabled = false;
      F2.Enabled = !disableUIControls;
      AFCBox.Enabled = !disableUIControls;
      if (bnFSet.Enabled)
        FSet_Click(null, null);
      while (afc_active)
        Thread.Sleep(100);
    }

    private void Square_CheckedChanged(object sender, EventArgs e)
    {
      STOP_AFC(true);
      status_word = OPBITEN;
      write_9833(status_word);
    }

    private void SquareDiv2_CheckedChanged(object sender, EventArgs e)
    {
      STOP_AFC(true);
      status_word = OPBITEN | DIV2;
      write_9833(status_word);
    }

    private void Triangular_CheckedChanged(object sender, EventArgs e)
    {
      STOP_AFC(true);
      status_word = MODE;
      write_9833(status_word);
    }

    private void Sine_CheckedChanged(object sender, EventArgs e)
    {
      STOP_AFC(true);
      status_word = 0;
      write_9833(status_word);
    }

    private void AFC_CheckedChanged(object sender, EventArgs e)
    {
      Sine_CheckedChanged(null, null);
      F2.Enabled = true;
      AFCBox.Enabled = true;
    }

    private static void freq_set(long freq)
    {
      long code = freq * (long)(1 << 28) / F_MCLK / 10;
      int code_lo = (int)(code & 0x3FFF);
      int code_hi = (int)((code >> 14) & 0x3FFF);
      if (code_hi != freq_word2)
      {
        status_word |= B28;
        write_9833(status_word, code_lo | FREQ_REG0, code_hi | FREQ_REG0);
      }
      else
      {
        status_word &= ~B28;
        write_9833(status_word, code_lo | FREQ_REG0);
      }
      freq_word1 = code_lo;
      freq_word2 = code_hi;
    }

    private void FSet_Click(object sender, EventArgs e)
    {
      int freq = (int)(float.Parse(F1.Text)*10);
      if (freq > 125000000)
      {
        MessageBox.Show("Invalid F1 value");
        return;
      }

      int freq2 = freq;
      if (F2.Enabled)
      {
        freq2 = (int)(float.Parse(F2.Text) * 10);
        if (freq2 > 125000000 || freq2 <= freq)
        {
          MessageBox.Show("Invalid F2 value");
          return;
        }
      }

      f1_value = freq;
      f2_value = freq2;
      int cnt = 1;
      int delay = int.Parse(bxSweepDelay.Text);

      if (freq != freq2)
      {
        if (bxPointsCount.TextLength > 0)
        {
          cnt = int.Parse(bxPointsCount.Text);
          resolution = (freq2 - freq) / cnt;
          bxCrossUpdateBlocked = true;
          bxResolution.Text = (((float)resolution) / 10).ToString();
          bxCrossUpdateBlocked = false;
        }
        else
        {
          resolution = (int)(float.Parse(bxResolution.Text) * 10);
          cnt = (freq2 - freq) / resolution;
          bxCrossUpdateBlocked = true;
          bxPointsCount.Text = cnt.ToString();
          bxCrossUpdateBlocked = false;
        }

        AFCResultsBuffer = new float[cnt + 1];
        bnStopAFC.Enabled = true;
      }

      int[] p = new int[4];
      p[0] = freq;
      p[1] = freq2;
      p[2] = resolution;
      p[3] = delay;
      parameters.Enqueue(p);

      F1Label.Text = (freq / 10).ToString();
      if (F2.Enabled)
        F2Label.Text = (freq2 / 10).ToString();
      else
        F2Label.Text = "-";
    }

    private void AFCSet_Click(object sender, EventArgs e)
    {
      FSet_Click(null, null);
    }

    private static void write_9833(params int[] words)
    {
      string command = "w";
      foreach (int w in words)
        command += string.Format("{0:X4}", w);

      cp.Write(command + "\r");
      string responce = Read(2);
      if (responce == null)
        throw new Exception("NULL responce from device.");
      if (!responce.Equals("Ok"))
      {
        Read();
        throw new Exception("Invalid responce from device - " + responce);
      }
    }

    private void F1_TextChanged(object sender, EventArgs e)
    {
      bnFSet.Enabled = !((F2.Enabled && F2.TextLength == 0) || F1.TextLength == 0);
    }

    private void F2_TextChanged(object sender, EventArgs e)
    {
      bool bEnable = !(F2.TextLength == 0 || F1.TextLength == 0 ||
                       (bxResolution.TextLength == 0 && bxPointsCount.TextLength == 0) || bxSweepDelay.TextLength == 0);

      if (bEnable)
      {
        float v = bxResolution.TextLength > 0 ? float.Parse(bxResolution.Text) : float.Parse(bxPointsCount.Text);
        int v1 = int.Parse(bxSweepDelay.Text);
        bEnable = v != 0 && v1 != 0;
      }

      bnFSet.Enabled = bEnable;
      bnAFCSet.Enabled = bEnable;
    }

    // input_level_in_db = 85 * (level_in_mv - 500) / 2060 - 75
    private static float get_input_level_db()
    {
      cp.Write("r");
      String responce = Read(5);
      bool stable = responce[0] == 'S';
      responce = responce.Substring(1);
      int code = int.Parse(responce, System.Globalization.NumberStyles.HexNumber); // 1024 = 2.56V
      float level_in_mv = (float)code * 5 / 2;
      return 85 * (level_in_mv - 500) / 2060 - 75;
    }

    public static void ControlProc()
    {
      int f1 = 0, f2 = 0, step = 0, delay = 0;

      while (true)
      {
        if (parameters.Count == 0)
        {
          if (f1 == f2)
            Thread.Sleep(100);
          else
          {
            afc_active = true;

            int i = 0;
            float[] buffer = AFCResultsBuffer;

            for (int f = f1; f <= f2; f += step)
            {
              if (stop)
                return;
              freq_set(f);
              if (delay > 0)
                Thread.Sleep(delay);
              buffer[i++] = get_input_level_db();
            }
            afc_active = false;
            UpdateUI();
          }
        }
        else
        {
          int[] p = parameters.Dequeue();
          f1 = p[0];
          f2 = p[1];
          if (f1 == f2)
            freq_set(f1);
          else
          {
            step = p[2];
            delay = p[3];
          }
        }

        if (stop)
          break;
      }
    }

    private void Resolution_TextChanged(object sender, EventArgs e)
    {
      if (!bxCrossUpdateBlocked)
      {
        bxCrossUpdateBlocked = true;
        bxPointsCount.Text = string.Empty;
        bxCrossUpdateBlocked = false;
        F2_TextChanged(null, null);
      }
    }

    private void SweepFreq_TextChanged(object sender, EventArgs e)
    {
      F2_TextChanged(null, null);
    }

    private static void UpdateUI()
    {
      if (!configLoaded)
        return;

      int steps = (level_max - level_min) / 9;
      int delta = panel.Size.Height / steps;
      float koef = (float)panel.Size.Height / (level_max - level_min);

      memDC.FillRectangle(backColorBrush, 0, 0, panel.Size.Width, panel.Size.Height);

      int level = level_max;
      for (int i = 0; i <= panel.Size.Height; i += delta)
      {
        memDC.DrawLine(yGridPen, 0, i, panel.Size.Width, i);
        if (AFCResultsBuffer == null)
          memDC.DrawString(level.ToString(), yAxisFont, yAxisFontBrush, 0, i - yAxisFont.Height);
        level -= steps;
      }

      if (AFCResultsBuffer != null)
      {
        float delta_f = (float)panel.Size.Width / (AFCResultsBuffer.Length - 1);
        float x_pos = 0;
        for (int i = 0; i < AFCResultsBuffer.Length; i++)
        {
          memDC.DrawLine(xGridPen, x_pos, 0, x_pos, panel.Size.Height);
          if (i > 0)
            memDC.DrawLine(AFCPen, x_pos - delta_f, get_y_pos(koef, i - 1), x_pos, get_y_pos(koef, i));

          x_pos += delta_f;
        }

        level = level_max;
        float nextX = 0;
        for (int i = 0; i <= panel.Size.Height; i += delta)
        {
          string text = level.ToString();
          SizeF size = memDC.MeasureString(text, yAxisFont);
          if (size.Width > nextX)
            nextX = size.Width;
          memDC.DrawString(text, yAxisFont, yAxisFontBrush, 0, i - yAxisFont.Height);
          level -= steps;
        }

        int f = f1_value;
        x_pos = 0;
        nextX += 5;
        for (int i = 0; i < AFCResultsBuffer.Length; i++)
        {
          if (i > 1 && x_pos >= nextX)
          {
            string text = (f/10).ToString();
            SizeF size = memDC.MeasureString(text, xAxisFont);
            memDC.DrawLine(xGridMarkedPen, x_pos, 0, x_pos, panel.Size.Height);
            memDC.DrawString(text, xAxisFont, xAxisFontBrush, x_pos, panel.Size.Height - size.Height);
            nextX = x_pos + size.Width + 5;
          }

          x_pos += delta_f;
          f += resolution;
        }
      }
      panel.Invalidate();
    }

    private static float get_y_pos(float koef, int i)
    {
      return panel.Size.Height - (AFCResultsBuffer[i] - level_min) * koef;
    }

    private void AFCPanel_Paint(object sender, PaintEventArgs e)
    {
      if (memDC != null)
      {
        IntPtr hdc = e.Graphics.GetHdc();
        IntPtr hMemdc = memDC.GetHdc();
        Win32Support.BitBlt(hdc,
                            0, 0,
                            this.Width, this.Height,
                            hMemdc,
                            0, 0,
                            Win32Support.TernaryRasterOperations.SRCCOPY);
        e.Graphics.ReleaseHdc(hdc);
        memDC.ReleaseHdc(hMemdc);
      }
    }

    private void AFCPanel_Resize(object sender, EventArgs e)
    {
      if (AFCPanel.Width == 0 || AFCPanel.Height == 0)
        return;

      Bitmap memBmp;
      memBmp = new Bitmap(AFCPanel.Width, AFCPanel.Height);

      Graphics clientDC = AFCPanel.CreateGraphics();
      IntPtr hdc = clientDC.GetHdc();
      IntPtr memdc = Win32Support.CreateCompatibleDC(hdc);
      Win32Support.SelectObject(memdc, memBmp.GetHbitmap());
      memDC = Graphics.FromHdc(memdc); clientDC.ReleaseHdc(hdc);
      UpdateUI();
    }

    private void bnOff_CheckedChanged(object sender, EventArgs e)
    {
      STOP_AFC(true);
    }

    private void bnStopAFC_Click(object sender, EventArgs e)
    {
      STOP_AFC(false);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void bxPointsCount_TextChanged(object sender, EventArgs e)
    {
      if (!bxCrossUpdateBlocked)
      {
        bxCrossUpdateBlocked = true;
        bxResolution.Text = string.Empty;
        bxCrossUpdateBlocked = false;
        F2_TextChanged(null, null);
      }
    }
  }
}
