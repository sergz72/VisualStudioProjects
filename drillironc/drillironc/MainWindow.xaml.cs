using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;
using classes2;

namespace drillironc
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, ICommandHandler
  {
    private System.Timers.Timer timer;
    private DeviceCommand deviceCommand;
    private bool disableCheckStatus;

    public MainWindow()
    {
      InitializeComponent();
      App app = (App)Application.Current;
      if (app.nextCommands != null)
      {
        if (app.settings.ContainsKey("window.position"))
        {
          string[] parts = app.settings["window.position"].Split(';');
          if (parts.Length == 4)
          {
            double x = double.Parse(parts[0]);
            double y = double.Parse(parts[1]);
            double w = double.Parse(parts[2]);
            double h = double.Parse(parts[3]);
            this.Left = x;
            this.Top = y;
            this.Width = w;
            this.Height = h;
          }
        }
        drill.loadSettings(app.settings);
        heater1.loadSettings(app.settings);
        heater2.loadSettings(app.settings);
        heater3.loadSettings(app.settings);

        timer = new System.Timers.Timer(250);

        // Hook up the Elapsed event for the timer.
        timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
        timer.Enabled = true;

        app.nextCommands.Enqueue(new DeviceCommand("s", this));//status
        deviceCommand = null;
        disableCheckStatus = false;
      }
    }

    private void OnTimerEvent(object source, ElapsedEventArgs e)
    {
      App app = (App)Application.Current;
      try
      {
        if (deviceCommand == null)
        {
          if (app.nextCommands.Count > 0)
          {
            deviceCommand = app.nextCommands.Dequeue();
            app.p.Write(deviceCommand.command);
            //Console.WriteLine("Command: " + deviceCommand.command);
          }
        }
        else
        {
          DeviceCommand c = deviceCommand;
          deviceCommand = null;
          string deviceAnswer = app.p.ReadExisting();
          if (deviceAnswer == null)
            deviceAnswer = string.Empty;
          //Console.WriteLine("Answer: " + deviceAnswer);
          if (!c.handler.CheckAnswer(c.command, deviceAnswer))
            MessageBox.Show("Command = " + c.command + ", answer = " + deviceAnswer,
                            "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
          if (app.nextCommands.Count == 0 && !disableCheckStatus)
            app.nextCommands.Enqueue(new DeviceCommand("s", this));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Comm port error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void ButtonExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    public bool CheckAnswer(string command, string answer)
    {
      if (answer.Length != 13)
        return false;

      bool button_pressed = answer[12] != '0';

      heater1.updateStatus(answer.Substring(0, 4), button_pressed);
      heater2.updateStatus(answer.Substring(4, 4), button_pressed);
      heater3.updateStatus(answer.Substring(8, 4), button_pressed);
      
      return true;
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      App app = (App)Application.Current;
      if (app.nextCommands != null)
      {
        disableCheckStatus = true;
        heater1.processCloseEvent();
        heater2.processCloseEvent();
        heater3.processCloseEvent();
        while (app.nextCommands.Count > 0)
          Thread.Sleep(500);
        timer.Enabled = false;
        app.settings.Clear();
        drill.saveSettings(app.settings);
        heater1.saveSettings(app.settings);
        heater2.saveSettings(app.settings);
        heater3.saveSettings(app.settings);
        string position = string.Format("{0};{1};{2};{3}", this.Left, this.Top, this.Width, this.Height);
        app.settings.Add("window.position", position);
        app.saveSettings();
      }
    }
  }
}
