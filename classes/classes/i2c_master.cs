using System;
using System.Windows.Forms;

namespace classes
{
  public class i2c_master: i2c
  {
    protected CommPortLogged cpl;

    public i2c_master(CommPortLogged c)
    {
      cpl = c;
    }

    public void Write(byte Address, params byte[] data)
    {
      string s = string.Format("i{0:X2}", Address);

      foreach (byte d in data)
        s += string.Format("{0:X2}", d);

      RawWrite(s);
    }

    public void RawWrite(string s)
    {
      try
      {
        cpl.Write(s + "\r");
        cpl.wait_OK();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.ToString());
      }
    }
  }
}
