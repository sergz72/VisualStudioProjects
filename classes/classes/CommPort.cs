using System;
using System.IO.Ports;
using System.Configuration;
using System.IO;

namespace classes
{
  public class CommPort: SerialPort
  {
    public CommPort(string port_name, string keys_prefix)
    {
      PortName = port_name;
      if (keys_prefix != null)
      {
        try
        {
          BaudRate = int.Parse(ConfigurationManager.AppSettings[keys_prefix + "BaudRate"]);
        }
        catch (Exception)
        {
          throw new ArgumentException("BaudRate value is incorrect");
        }

        string temp = ConfigurationManager.AppSettings[keys_prefix + "Parity"];
        if (temp != null)
        {
          if (temp.Equals("None"))
            Parity = Parity.None;
          else if (temp.Equals("Odd"))
            Parity = Parity.Odd;
          else if (temp.Equals("Even"))
            Parity = Parity.Even;
          else if (temp.Equals("Mark"))
            Parity = Parity.Mark;
          else if (temp.Equals("Space"))
            Parity = Parity.Space;
          else
            throw new ArgumentException("Parity value is incorrect");
        }

        temp = ConfigurationManager.AppSettings[keys_prefix + "DataBits"];
        if (temp != null)
        {
          try
          {
            DataBits = int.Parse(temp);
          }
          catch (Exception)
          {
            throw new ArgumentException("DataBits value is incorrect");
          }
        }

        temp = ConfigurationManager.AppSettings[keys_prefix + "StopBits"];
        if (temp != null)
        {
          if (temp.Equals("1"))
            StopBits = StopBits.One;
          else if (temp.Equals("2"))
            StopBits = StopBits.Two;
          else if (temp.Equals("1.5"))
            StopBits = StopBits.OnePointFive;
          else
            throw new ArgumentException("StopBits value is incorrect");
        }
      }
    }
  }
}
