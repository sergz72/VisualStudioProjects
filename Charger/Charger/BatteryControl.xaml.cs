using System.Windows;
using System.Windows.Controls;

namespace Charger
{
  /// <summary>
  /// Interaction logic for BatteryControl.xaml
  /// </summary>
  public partial class BatteryControl : UserControl
  {
    public int BatteryID { get; set; }

    public BatteryControl()
    {
      InitializeComponent();
    }

    private void bnStatus_Click(object sender, RoutedEventArgs e)
    {
      if ("OFF".Equals(bnStatus.Content))
        ON();
      else
        OFF();
    }

    private string getSelectedVoltage()
    {
      return (string)((ComboBoxItem)cbVSet.SelectedItem).Tag;
    }

    private string getSelectedCurrent()
    {
      return (string)((ComboBoxItem)cbISet.SelectedItem).Tag;
    }

    private void ON()
    {
      string selectedVoltage = getSelectedVoltage();
      int selectedVoltageValue = int.Parse(selectedVoltage);
      int factVoltage = int.Parse(tbVFact.Text.Replace(".", ""));
      if (selectedVoltageValue > 300 && factVoltage < 250) // Lithium battery
      {
        MessageBox.Show("Battery voltage should be >= 2.5V",
                        "Unable to start charging", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      else if (selectedVoltageValue < 200 && factVoltage < 70) // NiMh battery
      {
        MessageBox.Show("Battery voltage should be >= 0.7V",
                        "Unable to start charging", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      MainWindow w = (MainWindow)Application.Current.MainWindow;
      string code = BatteryID + selectedVoltage + getSelectedCurrent() + "\r";
      w.nextCommands.Enqueue(code);
      bnStatus.Content = "ON";
    }

    private void OFF()
    {
      MainWindow w = (MainWindow)Application.Current.MainWindow;
      w.nextCommands.Enqueue(BatteryID + "00000\r");
      bnStatus.Content = "OFF";
    }

    public void Reset()
    {
      bnStatus.Content = "OFF";
    }

    private delegate void updateValueProc(string value);

    public void updateStatus(string status)
    {
      lbStatus.Dispatcher.BeginInvoke(new updateValueProc(updateValue), status);
    }

    private void updateValue(string value)
    {
      lbStatus.Content = value;
      //0000 000 0000 000 0000
      tbVFact.Text = value.Substring(9, 1) + "." + value.Substring(10, 2);
      tbIFact.Text = "0." + value.Substring(14, 2);
    }
  }
}
