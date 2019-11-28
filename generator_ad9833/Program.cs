using System;
using System.Windows.Forms;
using classes;

namespace generator_ad9833
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      if (args.Length != 1)
      {
        MessageBox.Show("usage: generator_ad9833 [port_name]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

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
      Application.Run(new MainForm(p));
    }
  }
}
