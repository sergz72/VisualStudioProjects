using System;
using System.Text;
using System.Windows;
using classes2;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace gen_freq_meter_level_meter
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public CommPort p { get; private set; }
    public Queue<DeviceCommand> nextCommands { get; private set; }
    public Dictionary<string, string> settings { get; private set; }
    private const string settingsFile = "gen_freq_meter_level_meter.settings";

    protected override void OnStartup(StartupEventArgs e)
    {
      if (e.Args.Length != 1)
      {
        MessageBox.Show("usage: gen_freq_meter_level_meter [port_name]", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(1);
        return;
      }

      if (!"NODEVICE".Equals(e.Args[0]))
      {
        string answer;

        try
        {
          p = new CommPort(e.Args[0], string.Empty);
          p.ReadTimeout = 300;
          p.WriteTimeout = 300;
          p.Open();
          p.Write("I");
          Thread.Sleep(100);
          answer = p.ReadExisting();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Comm port openning error", MessageBoxButton.OK, MessageBoxImage.Error);
          Shutdown(2);
          return;
        }

        if (answer != "GNFMLM10")
        {
          MessageBox.Show("Wrong device answer to identify command: " + (answer == null ? string.Empty : answer), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          Shutdown(3);
          return;
        }

        nextCommands = new Queue<DeviceCommand>();
      }
      else
        nextCommands = null;

      settings = new Dictionary<string, string>();
      if (File.Exists(settingsFile))
      {
        foreach (string line in File.ReadAllLines(settingsFile))
        {
          string[] parts = line.Split(' ');
          if (parts.Length == 2)
            settings.Add(parts[0], parts[1]);
        }
      }

      base.OnStartup(e);
    }

    public void saveSettings()
    {
      StringBuilder text = new StringBuilder();
      foreach (var kvp in settings)
        text.Append(kvp.Key).Append(" ").Append(kvp.Value).Append("\r\n");
      File.WriteAllText(settingsFile, text.ToString());
    }
  }
}
