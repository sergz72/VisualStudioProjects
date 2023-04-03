using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.IO;
using System.Text;
using classes2;

namespace drillironc
{
  public interface ICommandHandler
  {
    bool CheckAnswer(string command, string answer);
  }

  public class DeviceCommand
  {
    public readonly string command;
    public readonly ICommandHandler handler;

    public DeviceCommand(string c, ICommandHandler h)
    {
      command = c;
      handler = h;
    }
  }

  public class HeaterProfile
  {
    public readonly string title;
    public readonly int ID, heaterID;
    public readonly double multipler, adder;
    public int default_temperature_low, default_temperature_high;

    public HeaterProfile(string title, int ID, int heaterID, double multipler, double adder, bool dual_temp_enable)
    {
      this.title = title;
      this.ID = ID;
      this.heaterID = heaterID;
      this.multipler = multipler;
      this.adder = adder;
      this.default_temperature_low = 150;
      this.default_temperature_high = dual_temp_enable ? 170 : -1;
    }

    public int calculateCode(double temperature)
    {
      int code = (int)(multipler * temperature + adder);
      return code;
    }
  }

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public CommPort p { get; private set; }
    public List<HeaterProfile>[] heaterProfiles { get; private set; }
    public string drill_title { get; private set; }
    public string program_title { get; private set; }
    public Queue<DeviceCommand> nextCommands { get; private set; }
    public Dictionary<string, string> settings { get; private set; }
    private const string settingsFile = "drillironc.settings";

    protected override void OnStartup(StartupEventArgs e)
    {
      if (e.Args.Length != 1)
      {
        MessageBox.Show("usage: drillironc [port_name]", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(1);
        return;
      }

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
        MessageBox.Show(ex.Message, "Comm port opening error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(2);
        return;
      }

      if (answer != "DRILLIRONC1.0")
      {
        MessageBox.Show("Wrong device answer to identify command: " + (answer == null ? string.Empty : answer), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(3);
        return;
      }

      drill_title = ConfigurationManager.AppSettings["drill_title"];
      program_title = ConfigurationManager.AppSettings["program_title"];

      heaterProfiles = new List<HeaterProfile>[3];
      for (int i = 0; i < 3; i++)
        heaterProfiles[i] = new List<HeaterProfile>();
      for (int i = 1; ; i++)
      {
        double multipler, adder;
        int heaterID;
        string prefix = "profile" + i;
        string parameter = prefix + "_title";
        string title = ConfigurationManager.AppSettings[parameter];
        if (title == null)
          break;
        parameter = prefix + "_heaterID";
        string value = ConfigurationManager.AppSettings[parameter];
        if (value == null || !int.TryParse(value, out heaterID) || heaterID < 1 || heaterID > 3)
        {
          MessageBox.Show("Wrong " + parameter + " parameter: " + (value == null ? string.Empty : value), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          Shutdown(4);
          return;
        }
        parameter = prefix + "_adder";
        value = ConfigurationManager.AppSettings[parameter];
        if (value == null || !double.TryParse(value, out adder))
        {
          MessageBox.Show("Wrong " + parameter + " parameter: " + (value == null ? string.Empty : value), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          Shutdown(4);
          return;
        }
        parameter = prefix + "_multipler";
        value = ConfigurationManager.AppSettings[parameter];
        if (value == null || !double.TryParse(value, out multipler) || multipler == 0)
        {
          MessageBox.Show("Wrong " + parameter + " parameter: " + (value == null ? string.Empty : value), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          Shutdown(4);
          return;
        }
        parameter = prefix + "_dual_temp";
        value = ConfigurationManager.AppSettings[parameter];
        bool dual_temp_enabled = value != null && value.Equals("true", StringComparison.OrdinalIgnoreCase);
        heaterProfiles[heaterID - 1].Add(new HeaterProfile(title, i, heaterID, multipler, adder, dual_temp_enabled));
      }
      nextCommands = new Queue<DeviceCommand>();
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
