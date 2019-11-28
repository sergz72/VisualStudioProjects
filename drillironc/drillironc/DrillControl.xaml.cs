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

namespace drillironc
{
  /// <summary>
  /// Interaction logic for DrillControl.xaml
  /// </summary>
  public partial class DrillControl : UserControl, ICommandHandler
  {
    private Button activePowerButton, activeTimeButton;
    public DrillControl()
    {
      InitializeComponent();
    }

    private void ButtonP_Click(object sender, RoutedEventArgs e)
    {
      activePowerButton.FontWeight = FontWeights.Normal;
      Button b = (Button)sender;
      b.FontWeight = FontWeights.Bold;
      string power = b.Content.ToString();
      int p = int.Parse(power.Substring(0, power.Length - 1));
      activePowerButton = b;
      setPower(p);
    }

    private void setPower(int p)
    {
      App app = (App)Application.Current;
      tbPower.Text = p.ToString() + "%";
      if (p > 99)
        p = 99;
      app.nextCommands.Enqueue(new DeviceCommand("d" + p, this));
    }

    private void ButtonR_Click(object sender, RoutedEventArgs e)
    {
      activeTimeButton.FontWeight = FontWeights.Normal;
      Button b = (Button)sender;
      b.FontWeight = FontWeights.Bold;
      string time = b.Content.ToString();
      activeTimeButton = b;
      setTime(time);
    }

    private void setTime(string time)
    {
      App app = (App)Application.Current;
      tbTime.Text = time;
      time = time.Substring(0, 1) + time.Substring(2, 1);
      app.nextCommands.Enqueue(new DeviceCommand("r" + time, this));
    }

    public void loadSettings(Dictionary<string, string> settings)
    {
      string key = "drill.power";
      if (settings.ContainsKey(key))
      {
        int value = int.Parse(settings[key]);
        switch (value)
        {
          case 10: activePowerButton = bn10; break;
          case 20: activePowerButton = bn20; break;
          case 30: activePowerButton = bn30; break;
          case 40: activePowerButton = bn40; break;
          case 50: activePowerButton = bn50; break;
          case 60: activePowerButton = bn60; break;
          case 70: activePowerButton = bn70; break;
          case 80: activePowerButton = bn80; break;
          case 90: activePowerButton = bn90; break;
          case 100: activePowerButton = bn100; break;
          default: activePowerButton = bn100; break;
        }
        setPower(value);
      }
      else
      {
        activePowerButton = bn100;
        setPower(100);
      }
      activePowerButton.FontWeight = FontWeights.Bold;

      key = "drill.rise_time";
      if (settings.ContainsKey(key))
      {
        string value = settings[key];
        switch (value)
        {
          case "0.2": activeTimeButton = bn02; break;
          case "0.4": activeTimeButton = bn04; break;
          case "0.6": activeTimeButton = bn06; break;
          case "0.8": activeTimeButton = bn08; break;
          case "1.0": activeTimeButton = bn1; break;
          case "1.2": activeTimeButton = bn12; break;
          case "1.4": activeTimeButton = bn14; break;
          case "1.6": activeTimeButton = bn16; break;
          case "1.8": activeTimeButton = bn18; break;
          case "2.0": activeTimeButton = bn2; break;
          default: activeTimeButton = bn1; break;
        }
      }
      else
        activeTimeButton = bn1;

      setTime(activeTimeButton.Content.ToString());
      activeTimeButton.FontWeight = FontWeights.Bold;
    }

    public void saveSettings(Dictionary<string, string> settings)
    {
      string power = activePowerButton.Content.ToString();
      power = power.Substring(0, power.Length - 1);
      settings.Add("drill.power", power);
      settings.Add("drill.rise_time", activeTimeButton.Content.ToString());
    }

    public bool CheckAnswer(string command, string answer)
    {
      return answer == "K";
    }
  }
}
