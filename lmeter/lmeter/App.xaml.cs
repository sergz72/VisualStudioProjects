using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using classes2;

namespace lmeter
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public CommPort p { get; private set; }
    private double c;
    public double C { get { return c; } }

    protected override void OnStartup(StartupEventArgs e)
    {
      if (e.Args.Length != 1)
      {
        MessageBox.Show("usage: lmeter [port_name]", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

      if (answer != "LMETER1.0")
      {
        MessageBox.Show("Wrong device answer to identify command: " + (answer == null ? string.Empty : answer), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(3);
        return;
      }

      string cs = ConfigurationManager.AppSettings["C"];
      if (cs == null || !double.TryParse(cs, out c))
      {
        MessageBox.Show("Wrong C parameter: " + (cs == null ? string.Empty : cs), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(4);
        return;
      }

      base.OnStartup(e);
    }
  }
}
