using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace classes
{
  public class CommPortLogged
  {
    protected CommPort cp;
    protected TextBox log_box;
    protected Queue<char> chars;
    public string responce;
    private bool enable_echo;

    public string get_responce()
    {
      int time = 0;

      while (responce == null)
      {
        Thread.Sleep(20);
        time += 20;
        if (time > 2000)
            throw new TimeoutException();
      }

      string r = responce;
      responce = null;
      return r;
    }

    public void wait_OK()
    {
      string r = get_responce();
      if (!r.Equals("Ok"))
        throw new ArgumentException("Invalid responce: " + r);
    }

    public CommPortLogged(TextBox logbox, CommPort cport, bool echo_enable)
    {
      log_box = logbox;
      cp = cport;
      enable_echo = echo_enable;
      if (cp != null)
      {
        cp.ReadTimeout = 100;
        cp.WriteTimeout = 100;
      }

      chars = new Queue<char>();

      responce = null;

      if (log_box != null)
        log_box.KeyPress += new KeyPressEventHandler(log_box_KeyPress);
    }

    protected void log_box_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (cp != null)
      {
        string s = new string(e.KeyChar, 1);
        cp.Write(s);
        if (enable_echo)
          log_box.AppendText(s);
        if (e.KeyChar == '\r')
          Read();
        e.Handled = true;
      }
      else
        if (e.KeyChar == '\r')
          return_OK();
    }

    public int ReadChar()
    {
      if (cp != null)
        return cp.ReadByte();

      int time = 0;
      while (chars.Count == 0)
      {
        Thread.Sleep(20);
        time += 20;
        if (time > 200)
          throw new TimeoutException();
      }

      return chars.Dequeue();
    }

    public void return_OK()
    {
      chars.Enqueue('O');
      chars.Enqueue('k');
    }

    public void return_str(string str)
    {
      foreach (char c in str)
        chars.Enqueue(c);
    }

    public void Write(string text)
    {
      responce = null;

      if (cp != null)
      {
        cp.Write(text);
        if (enable_echo)
          log_box.AppendText(text);
      }
      else
      {
        return_str(text + "\n");

        if (text.Contains("\r"))
          return_OK();
      }
    }

    public void Close()
    {
      if (cp != null)
      {
        try { cp.Close(); }
        catch (Exception) { }
      }
    }

    public string Read()
    {
      return Read(-1);
    }

    public string Read(int exp_cnt)
    {
      char[] buffer = new char[2000];

      int cnt = 0;

      try
      {
        while (true)
        {
          char c = (char)ReadChar();
          buffer[cnt] = c;
          cnt++;
          if ((cnt > 1 && (c == 'k' && buffer[cnt - 2] == 'O')) ||
              (cnt > 2 && (c == 'r' && buffer[cnt - 3] == 'E' && buffer[cnt - 2] == 'r')) ||
               cnt == exp_cnt)
            break;
        }
      }
      catch (TimeoutException)
      {
      }

      if (cnt > 0)
      {
        string s = new String(buffer, 0, cnt);
        log_box.AppendText(s);
        return s;
      }

      return null;
    }
  }
}
