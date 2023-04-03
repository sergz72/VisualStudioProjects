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
using System.Collections;
using classes2;

namespace lmeter
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private Timer timer;
    private Queue<string> nextCommands;
    private string deviceAnswer;
    private int mode;
    private const int MODE_L = 0;
    private const int MODE_C = 1;

    public MainWindow()
    {
      InitializeComponent();
      // 500ms interval
      timer = new Timer(500);

      // Hook up the Elapsed event for the timer.
      timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
      timer.Enabled = true;

      nextCommands = new Queue<string>();
      nextCommands.Enqueue("F");
      deviceAnswer = "1";
      mode = MODE_L;
    }

    private delegate void updateValueProc();

    private void OnTimerEvent(object source, ElapsedEventArgs e)
    {
      App app = (App)Application.Current;
      try
      {
        if (deviceAnswer != null)
        {
          app.p.Write(nextCommands.Peek());
//          Console.WriteLine("Command: " + nextCommands.Peek());
          deviceAnswer = null;
        }
        else
        {
          deviceAnswer = app.p.ReadExisting();
          if (deviceAnswer == null)
            deviceAnswer = string.Empty;
//          Console.WriteLine("Answer: " + deviceAnswer);
          switch (nextCommands.Peek())
          {
            case "L":
              if (deviceAnswer != "K")
                MessageBox.Show("Command = " + nextCommands.Peek() + ", answer = " + deviceAnswer,
                                "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
              break;
            case "C":
              if (deviceAnswer != "K")
                MessageBox.Show("Command = " + nextCommands.Peek() + ", answer = " + deviceAnswer,
                                "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
              break;
            case "F":
              tbValue.Dispatcher.BeginInvoke(new updateValueProc(updateValue));
              break;
          }
          nextCommands.Dequeue();
          if (nextCommands.Count == 0)
            nextCommands.Enqueue("F");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Comm port error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    private void updateValue()
    {
      App app = (App)Application.Current;
      tbFValue.Text = deviceAnswer;
      double F = double.Parse(deviceAnswer) / 1000000;
      double L = 25530 / F / F / app.C;
      if (L < 10)
      {
        string v = L.ToString("F2");
        tbValue.Text = v;
        tbUnits.Text = "uH";
      }
      else if (L < 100)
      {
        string v = L.ToString("F1");
        tbValue.Text = v;
        tbUnits.Text = "uH";
      }
      else if (L < 1000)
      {
        string v = L.ToString("F0");
        tbValue.Text = v;
        tbUnits.Text = "uH";
      }
      else if (L < 10000)
      {
        string v = (L / 1000).ToString("F2");
        tbValue.Text = v;
        tbUnits.Text = "mH";
      }
      else if (L < 100000)
      {
        string v = (L / 1000).ToString("F1");
        tbValue.Text = v;
        tbUnits.Text = "mH";
      }
      else
      {
        string v = (L / 1000).ToString("F0");
        tbValue.Text = v;
        tbUnits.Text = "mH";
      }
    }

    private void bnExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
    private void bnL_Click(object sender, RoutedEventArgs e)
    {
      nextCommands.Enqueue("L");
    }
    private void bnC_Click(object sender, RoutedEventArgs e)
    {
      nextCommands.Enqueue("C");
    }
  }
}
