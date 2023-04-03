using System;
using System.Windows;
using classes2;
using System.Threading;
using System.Configuration;

namespace Charger
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public CommPort p { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
      if (e.Args.Length != 1)
      {
        MessageBox.Show("usage: charger [port_name]", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
        p.Write("I\r");
        Thread.Sleep(100);
        answer = p.ReadExisting();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Comm port opening error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(2);
        return;
      }

      if (answer != "CHG10")
      {
        MessageBox.Show("Wrong device answer to identify command: " + (answer == null ? string.Empty : answer), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Shutdown(3);
        return;
      }

      base.OnStartup(e);
    }
  }
}
