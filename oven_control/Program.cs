using System;
using System.Windows.Forms;
using classes;

namespace oven_control
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      string program_file = null;

      if (args.Length < 1 || args.Length > 2)
      {
        MessageBox.Show("usage: oven_control port_name [program_file]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      else if (args.Length == 2)
        program_file = args[1];

      CommPort p;

      p = new CommPort(args[0], string.Empty);
      try
      {
        p.Open();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message, "Comm port opening error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm(p, program_file));
    }
  }
}
