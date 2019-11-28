using System;
using System.Threading;
using System.Windows;
using System.Configuration;
using System.Windows.Media;
using System.Timers;

namespace gen_freq_meter_level_meter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, ICommandHandler
  {
    private const int COMMAND_BUFFER_SIZE = 16;
    private Thread commPortThread;
    private System.Timers.Timer timer;

    public MainWindow()
    {
      InitializeComponent();

      App app = (App)Application.Current;

      if (app.settings == null)
        return;

      if (app.settings.ContainsKey("window.position"))
      {
        string[] parts = app.settings["window.position"].Split(';');
        if (parts.Length == 2)
        {
          double x = double.Parse(parts[0]);
          double y = double.Parse(parts[1]);
          this.Left = x;
          this.Top = y;
        }
      }

      generator1.OutputNo = 0;
      generator1.GeneratorControl = new Generator_ADUC7129(app.nextCommands, int.Parse(ConfigurationManager.AppSettings["DDS_ADUC7129_Correction"]));
      generator1.ReadSettings(app.settings);
      generator1.SweepStatusChanged += Generator1_SweepStatusChanged;

      int correction = int.Parse(ConfigurationManager.AppSettings["DDS_AD9958_Correction"]);
      generator2.GeneratorControl = new Generator_AD9958(app.nextCommands, correction, 0);
      generator2.ReadSettings(app.settings);
      generator2.SweepStatusChanged += Generator2_SweepStatusChanged;

      generator3.GeneratorControl = new Generator_AD9958(app.nextCommands, correction, 1);
      generator3.ReadSettings(app.settings);
      generator3.SweepStatusChanged += Generator3_SweepStatusChanged;

      meter1.Meter = new LevelMeterBase(-90, 5, double.Parse(ConfigurationManager.AppSettings["AD8310_Offset"]), double.Parse(ConfigurationManager.AppSettings["AD8310_Coef"]));
      meter2.Meter = new LevelMeterBase(-90, 5, double.Parse(ConfigurationManager.AppSettings["AD8313_Offset"]), double.Parse(ConfigurationManager.AppSettings["AD8313_Coef"]));

      if (app.nextCommands != null)
      {
        commPortThread = new Thread(CommPortThreadProc);
        commPortThread.Start();

        // 500ms interval
        timer = new System.Timers.Timer(500);

        // Hook up the Elapsed event for the timer.
        timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
        timer.Enabled = true;
      }
    }

    private void Generator3_SweepStatusChanged(object sender, bool status)
    {
      generator1.IsSweepEnabled = !status;
      generator2.IsSweepEnabled = !status;
    }

    private void Generator2_SweepStatusChanged(object sender, bool status)
    {
      generator1.IsSweepEnabled = !status;
      generator3.IsSweepEnabled = !status;
    }

    private void Generator1_SweepStatusChanged(object sender, bool status)
    {
      generator2.IsSweepEnabled = !status;
      generator3.IsSweepEnabled = !status;
    }

    private void OnTimerEvent(object source, ElapsedEventArgs e)
    {
      App app = (App)Application.Current;
      app.nextCommands.Enqueue(new DeviceCommand('S', null, null, null, this, 3));
    }

    private void CommPortThreadProc()
    {
      App app = (App)Application.Current;
      byte[] commandBytes = new byte[COMMAND_BUFFER_SIZE];

      int errorCount = 0;
      for (;;)
      {
        try
        {
          if (app.nextCommands.Count > 0)
          {
            DeviceCommand deviceCommand = app.nextCommands.Dequeue();
            int length = deviceCommand.getBytes(commandBytes);
            app.p.Write(commandBytes, 0, length);
            //Console.WriteLine("Command: " + deviceCommand.ToString());
            int attempts = 0;
            int offset = 0;
            length = deviceCommand.answerBytes;
            for (;;)
            {
              int count = app.p.Read(commandBytes, offset, length);
              length -= count;
              offset += count;
              if (length == 0)
                break;
              attempts++;
              if (attempts == 10)
              {
                MessageBox.Show("Command = " + deviceCommand.ToString() + ", answer length: expected = " + deviceCommand.answerBytes +
                                "received = " + offset + (offset == 0 ? "" : ", answer: " + BitConverter.ToString(commandBytes, 0, offset)),
                                "Wrong device answer length", MessageBoxButton.OK, MessageBoxImage.Error);
                break;
              }
            }
            if (length == 0)
            {
              //Console.WriteLine("Answer: " + BitConverter.ToString(commandBytes, 0, count)));
              if (!deviceCommand.CheckAnswer(commandBytes))
                MessageBox.Show("Command = " + deviceCommand.ToString() + ", answer = " + BitConverter.ToString(commandBytes, 0, offset),
                                "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          }
          else
            Thread.Sleep(1);
          errorCount = 0;
        }
        catch (ThreadAbortException)
        {
          break;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Comm port error", MessageBoxButton.OK, MessageBoxImage.Error);
          errorCount++;
        }
        if (errorCount > 3)
        {
          MessageBox.Show("Maximum error count reached. Giving up.", "Comm port error", MessageBoxButton.OK, MessageBoxImage.Error);
          break;
        }
      }
    }

    private void miExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (timer != null)
        timer.Enabled = false;
      App app = (App)Application.Current;
      if (app.settings == null)
        return;
      if (app.nextCommands != null)
      {
        while (app.nextCommands.Count > 0)
          Thread.Sleep(100);
        commPortThread.Abort();
      }
      app.settings.Clear();
      string position = string.Format("{0};{1}", this.Left, this.Top);
      app.settings.Add("window.position", position);
      generator1.SaveSettings(app.settings);
      app.saveSettings();
    }

    public void ShowStatus(string errorMessage, Boolean result)
    {
      if (result)
      {
        lMessage.Content = "OK";
        lMessage.Foreground = Brushes.Black;
      }
      else
      {
        lMessage.Content = errorMessage;
        lMessage.Foreground = Brushes.Red;
      }
    }

    public bool CheckAnswer(DeviceCommand command, byte[] answer)
    {
      uint mv;

      if (answer[0] != 'k')
        return false;

      mv = answer[2];
      mv <<= 8;
      mv += answer[1];

      meter1.UpdateStatus(mv);

      return true;
    }
  }
}
