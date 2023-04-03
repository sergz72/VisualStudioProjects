using System;
using System.Windows.Forms;

namespace classes
{
	/// <summary>
	/// Summary description for NumericBox.
	/// </summary>
	public class NumericBox: TextBox
	{
		protected bool AllowPoint, AllowMinus, blocked;

		public bool allowPoint { get { return AllowPoint; } set { AllowPoint = value; } }
    public bool allowMinus { get { return AllowMinus; } set { AllowMinus = value; } }

    public override string Text
    {
      get
      {
        if (!AllowPoint || Focused)
          return base.Text;
        return base.Text.Replace(" ", "").Replace("\xA0", "");
      }
      set
      {
        if (!AllowPoint || Focused)
          base.Text = value;
        else
          base.Text = formatNumber(value);
      }
    }

		public NumericBox()
		{
			AllowPoint = false;
			this.KeyPress += new KeyPressEventHandler(NumericBox_KeyPress);
      blocked = false;
		}

		public NumericBox(bool allowpoint)
		{
			AllowPoint = allowpoint;
			this.KeyPress  += new KeyPressEventHandler(NumericBox_KeyPress);
      blocked = false;
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);
      if (AllowPoint)
      {
        blocked = true;
        Text = Text.Replace(" ", "").Replace("\xA0", "");
        blocked = false;
      }
    }

    protected override void OnLostFocus(EventArgs e)
    {
      if (AllowPoint)
      {
        blocked = true;
        Text = Text;
        blocked = false;
      }
    }

    protected override void OnTextChanged(EventArgs e)
    {
      if (!blocked)
        base.OnTextChanged(e);
    }

		private void NumericBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '.')
			{
        if (AllowPoint && Text.IndexOf('.') != -1)
					e.Handled = true;
			}
      else if (e.KeyChar == '-')
      {
        if (AllowMinus && Text.IndexOf('-') != -1)
          e.Handled = true;
      }
      else if (e.KeyChar >= ' ' && (e.KeyChar < '0' || e.KeyChar > '9'))
				e.Handled = true;
		}

    public static string formatNumber(string text)
    {
      string s;

      int idx = text.IndexOf('.');
      if (idx == -1)
      {
        idx = text.Length;
        s   = string.Empty;
      }
      else
        s   = text.Substring(idx);

      while (idx > 0)
      {
        int idx2 = idx - 3;
/*        if (idx2 < 0)
          idx2 = 0;*/
        if (idx2 <= 0 || (idx2 == 1 && s.Length > 0 && s[0] == '-'))
        {
          idx2 = 0;
          s = text.Substring(idx2, idx - idx2) + s;
          break;
        }
        s = " " + text.Substring(idx2, idx - idx2) + s;
        idx = idx2;
      }

      return s.Trim();
    }
	}
}
