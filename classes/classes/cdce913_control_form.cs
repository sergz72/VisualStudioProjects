using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace classes
{
  public partial class cdce913_control_form : Form
  {
    i2c_master i2m;
    cdce913 device;

    public cdce913_control_form(i2c_master i2c_m, int clock_freq)
    {
      i2m = i2c_m;

      InitializeComponent();

      string Fosc = ConfigurationManager.AppSettings["CDCE913_FOSC"];

      int fosc = int.Parse(Fosc);

      device = new cdce913(fosc);

      FOSC.Text = Fosc;

      y1_frequency.Text = clock_freq.ToString();
    }

    private void bnInit_Click(object sender, EventArgs e)
    {
      device.init(i2m);
      bnFreqSet.Enabled = true;
      bnSave.Enabled = true;
      bnY1Disable.Enabled = true;
      bnY2Y3Enable.Enabled = true;
    }

    private void bnFreqSet_Click(object sender, EventArgs e)
    {
      device.set_fosc(int.Parse(FOSC.Text));
      try
      {
        device.set_y1_freq(i2m, int.Parse(y1_frequency.Text));
        y1_pdiv.Text = device.get_y1_pdiv().ToString();
        MessageBox.Show("Y1 frequency set to " + y1_frequency.Text);
      }
      catch (ArgumentOutOfRangeException)
      {
        MessageBox.Show("Error setting frequency");
        y1_pdiv.Text = string.Empty;
      }
    }

    private void bnY1Disable_Click(object sender, EventArgs e)
    {
      device.y1_off(i2m);
      bnY1Disable.Enabled = false;
      bnY1Enable.Enabled = true;
    }

    private void bnY1Enable_Click(object sender, EventArgs e)
    {
      device.y1_on(i2m);
      bnY1Disable.Enabled = true;
      bnY1Enable.Enabled = false;
    }

    private void bnY2Y3Disable_Click(object sender, EventArgs e)
    {
      device.y2y3_off(i2m);
      bnY2Y3Disable.Enabled = false;
      bnY2Y3Enable.Enabled = true;
    }

    private void bnY2Y3Enable_Click(object sender, EventArgs e)
    {
      device.y2y3_on(i2m);
      bnY2Y3Disable.Enabled = true;
      bnY2Y3Enable.Enabled = false;
    }

    private void bnSave_Click(object sender, EventArgs e)
    {
      device.eeprom_write(i2m);
      MessageBox.Show("Configuration saved to EEPROM");
    }

    private void bnY2PdivSet_Click(object sender, EventArgs e)
    {

    }

    private void bnY3PdivSet_Click(object sender, EventArgs e)
    {

    }

    private void y2_pdiv_TextChanged(object sender, EventArgs e)
    {
      bnY2PdivSet.Enabled = y2_pdiv.TextLength > 0;
    }

    private void y3_pdiv_TextChanged(object sender, EventArgs e)
    {
      bnY3PdivSet.Enabled = y3_pdiv.TextLength > 0;
    }

    private void y1_frequency_TextChanged(object sender, EventArgs e)
    {
      bnFreqSet.Enabled = FOSC.TextLength > 0 && y1_frequency.TextLength > 0;
    }

    private void FOSC_TextChanged(object sender, EventArgs e)
    {
      bnFreqSet.Enabled = FOSC.TextLength > 0 && y1_frequency.TextLength > 0;
    }
  }
}
