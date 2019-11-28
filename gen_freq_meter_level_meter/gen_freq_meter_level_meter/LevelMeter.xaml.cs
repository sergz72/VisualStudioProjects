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

namespace gen_freq_meter_level_meter
{
  /// <summary>
  /// Interaction logic for LevelMeter.xaml
  /// </summary>
  public partial class LevelMeter : UserControl
  {
    private LevelMeterBase meter;
    public LevelMeterBase Meter
    {
      get { return meter; }
      set {
        meter = value;
      }
    }

    public LevelMeter()
    {
      InitializeComponent();
    }

    private delegate void updateValueProc(uint mv);

    public void UpdateStatus(uint mv)
    {
      lbmV.Dispatcher.BeginInvoke(new updateValueProc(updateValue), mv);
    }

    private void updateValue(uint mv)
    {
      lbmV.Content = mv;
      if (meter != null)
        lbLevel.Content = meter.getLevel(mv).ToString("F1");
    }
  }
}
