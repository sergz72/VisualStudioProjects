using System.Collections.Generic;
using System.Windows;
using System.Timers;
using System;
using System.Threading;

namespace Charger
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private System.Timers.Timer timer;
    public Queue<string> nextCommands;
    private string deviceAnswer;
    private bool disableCheckStatus;
    private int failureCounter;

    public MainWindow()
    {
      InitializeComponent();
      // 500ms interval
      timer = new System.Timers.Timer(500);

      // Hook up the Elapsed event for the timer.
      timer.Elapsed += new ElapsedEventHandler(OnTimerEvent);
      timer.Enabled = true;

      nextCommands = new Queue<string>();
      nextCommands.Enqueue("S\r");
      deviceAnswer = "0000 000 0000 000 0000|0000 000 0000 000 0000|0000 000 0000 000 0000|";
      disableCheckStatus = false;
      failureCounter = 0;
    }

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
            case "R\r":
              break;
            case "S\r":
              if (!CheckAnswer())
                MessageBox.Show("Command = " + nextCommands.Peek() + ", answer = " + deviceAnswer,
                                "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
              break;
            default:
              if (deviceAnswer != "k")
                MessageBox.Show("Command = " + nextCommands.Peek() + ", answer = " + deviceAnswer,
                                "Wrong device answer", MessageBoxButton.OK, MessageBoxImage.Error);
              break;
          }
          nextCommands.Dequeue();
          if (nextCommands.Count == 0 && !disableCheckStatus)
            nextCommands.Enqueue("S\r");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Comm port error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    public bool CheckAnswer()
    {
      if (deviceAnswer.Length != 69)
      {
        failureCounter++;
        return failureCounter <= 5;
      }

      failureCounter = 0;

      battery0.updateStatus(deviceAnswer.Substring(0, 22));
      battery1.updateStatus(deviceAnswer.Substring(23, 22));
      battery2.updateStatus(deviceAnswer.Substring(46, 22));

      return true;
    }

    private void ButtonExit_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void ButtonReset_Click(object sender, RoutedEventArgs e)
    {
      nextCommands.Enqueue("R\r");
      battery0.Reset();
      battery1.Reset();
      battery2.Reset();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      disableCheckStatus = true;
      nextCommands.Enqueue("R\r");
      while (nextCommands.Count > 0)
        Thread.Sleep(500);
      timer.Enabled = false;
    }
  }
}
