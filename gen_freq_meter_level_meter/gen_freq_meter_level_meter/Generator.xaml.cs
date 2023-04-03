using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace gen_freq_meter_level_meter
{
  public delegate void ChangedEventHandler(object sender, bool status);

  /// <summary>
  /// Interaction logic for Generator.xaml
  /// </summary>
  public partial class Generator : UserControl
  {
    private GeneratorBase _GeneratorControl;
    public GeneratorBase GeneratorControl
    {
      private get
      {
        return _GeneratorControl;
      }
      set
      {
        _GeneratorControl = value;
        if (value != null)
        {
          cbSignalForm1.ItemsSource = value.Outputs[0].SupportedSignalForms;
          cbSignalForm1.SelectedIndex = 0;
          udLevel1.Value = value.Outputs[0].MaxLevel;
          udLevel1.Minimum = value.Outputs[0].MinLevel;
          udLevel1.Maximum = value.Outputs[0].MaxLevel;
          if (value.Outputs.Length == 1)
            gbOutput2.IsEnabled = false;
          else
          {
            cbSignalForm2.ItemsSource = value.Outputs[1].SupportedSignalForms;
            cbSignalForm2.SelectedIndex = 0;
            udLevel2.Value = value.Outputs[1].MaxLevel;
            udLevel2.Minimum = value.Outputs[1].MinLevel;
            udLevel2.Maximum = value.Outputs[1].MaxLevel;
          }
        }
      }
    }

    public bool IsSweepEnabled { get { return gbSweep.IsEnabled; } set { gbSweep.IsEnabled = value; } }

    public event ChangedEventHandler SweepStatusChanged;

    public int OutputNo { private get; set; }
    public int Output2No { private get; set; }

    private int tuneStep, sweepStep;

    public Generator()
    {
      InitializeComponent();

      tuneStep = sweepStep = 100;
    }

    public void ReadSettings(Dictionary<string, string> settings)
    {
    }

    public void SaveSettings(Dictionary<string, string> settings)
    {
    }

    private void cbOff1_Checked(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null)
        return;
      GeneratorControl.OutputEnable(OutputNo, false);
    }

    private void cbOff1_Unchecked(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null)
        return;
      GeneratorControl.OutputEnable(OutputNo, true);
    }

    private void cbOff2_Checked(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null)
        return;
      GeneratorControl.OutputEnable(Output2No, false);
    }

    private void cbOff2_Unchecked(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null)
        return;
      GeneratorControl.OutputEnable(Output2No, true);
    }

    private void cbTuneLock_Checked(object sender, RoutedEventArgs e)
    {
      udFrequency1.IsEnabled = false;
      udFrequency2.IsEnabled = false;
    }

    private void cbTuneLock_Unchecked(object sender, RoutedEventArgs e)
    {
      udFrequency1.IsEnabled = false;
      udFrequency2.IsEnabled = false;
    }

    private void cbSweep_Checked(object sender, RoutedEventArgs e)
    {
      udFrequency2.IsEnabled = true;
      bnSweepStart.IsEnabled = true;
      SweepStatusChanged(this, true);
    }

    private void cbSweep_Unchecked(object sender, RoutedEventArgs e)
    {
      udFrequency2.IsEnabled = false;
      bnSweepStart.IsEnabled = false;
      SweepStatusChanged(this, false);
    }

    private void bnFrequency_Click(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null || !udFrequency1.Value.HasValue || udFrequency1.Value.Value <= 0)
        return;

      ((MainWindow)Application.Current.MainWindow).ShowStatus("Error setting frequency.", GeneratorControl.SetFrequency((uint)udFrequency1.Value.Value));
    }

    private void bnSweepStart_Click(object sender, RoutedEventArgs e)
    {
      if (udSweepStep.IsEnabled)
      {
        if (GeneratorControl == null || !udSweepStep.Value.HasValue)
          return;

        sweepStep = udSweepStep.Value.Value;
        udSweepStep.IsEnabled = false;
        bnSweepStart.Content = "Stop";
      }
      else
      {
        udSweepStep.IsEnabled = true;
        bnSweepStart.Content = "Start";
      }
    }

    private void bnLevel1_Click(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null || !udLevel1.Value.HasValue)
        return;

      ((MainWindow)Application.Current.MainWindow).ShowStatus("Error setting output level.", GeneratorControl.SetLevel(OutputNo, udLevel1.Value.Value));
    }

    private void cbTuneStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      tuneStep = int.Parse(((ComboBoxItem)cbTuneStep.SelectedItem).Tag.ToString());
    }

    private void udLevel2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      if (GeneratorControl != null && udLevel2.Value.HasValue)
        lbRAWLevel2.Content = GeneratorControl.Outputs[1].CalculateLevelCode(udLevel2.Value.Value);
    }

    private void udLevel1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      if (GeneratorControl != null && udLevel1.Value.HasValue)
        lbRAWLevel1.Content = GeneratorControl.Outputs[0].CalculateLevelCode(udLevel1.Value.Value);
    }

    private void bnLevel2_Click(object sender, RoutedEventArgs e)
    {
      if (GeneratorControl == null || !udLevel2.Value.HasValue)
        return;

      ((MainWindow)Application.Current.MainWindow).ShowStatus("Error setting output level.", GeneratorControl.SetLevel(Output2No, udLevel2.Value.Value));
    }
  }
}
