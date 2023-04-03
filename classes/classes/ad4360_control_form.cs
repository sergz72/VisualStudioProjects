using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace classes
{
  public partial class ad4360_control_form : Form
  {
    ad4360 device;
    bool in_update;
    protected CommPortLogged cpl;

    public ad4360_control_form(CommPortLogged c, int clock_freq)
    {
      InitializeComponent();

      string Fosc = ConfigurationManager.AppSettings["AD4360_FOSC"];

      int fosc = int.Parse(Fosc);

      device = new ad4360(fosc);

      FOSC.Text = Fosc;

      out_freq.Text = clock_freq.ToString();

      corePowerLevel.Items.AddRange(device.CORE_POWER_LEVELS);
      corePowerLevel.SelectedIndex = device.CORE_POWER_LEVEL_DEFAULT;

      double icp = ad4360.ICP_STEP;
      for (int i = 0; i < ad4360.ICP_STEP_COUNT ; i++)
      {
        string value = icp.ToString() + " mA";
        currentSetting1.Items.Add(value);
        currentSetting2.Items.Add(value);
        icp += ad4360.ICP_STEP;
      }

      currentSetting1.SelectedIndex = 0;
      currentSetting2.SelectedIndex = 0;

      muxoutControl.Items.AddRange(device.MUXOUT_VALUES);
      muxoutControl.SelectedIndex = 1;

      outPowerLevel.Items.AddRange(device.OUTPUT_POWER_LEVELS);
      outPowerLevel.SelectedIndex = 3;

      antiBLPW.Items.AddRange(device.ANTI_BACKLASH_PULSE_WIDTHS);
      antiBLPW.SelectedIndex = 0;

      bandSelClockDiv.Items.AddRange(device.BAND_SELECT_CLOCK_DIVIDERS);
      bandSelClockDiv.SelectedIndex = 0;

      referenceFreq_TextChanged(null, null);
      out_freq_TextChanged(null, null);

      cpl = c;
    }

    private void bnFreqSet_Click(object sender, EventArgs e)
    {
      cpl.Write(string.Format("pl{0:X6}\r", buildNCounterWord()));
      cpl.wait_OK();
    }

    private void out_freq_TextChanged(object sender, EventArgs e)
    {
      bnFreqSet.Enabled = FOSC.TextLength > 0 && out_freq.TextLength > 0 &&
                          rCounterValue.TextLength > 0;

      if (out_freq.TextLength > 0 && rCounterValue.TextLength > 0)
      {
        try
        {
          nCounterValue.Text = device.calculate_n_counter_value(int.Parse(out_freq.Text), int.Parse(rCounterValue.Text)).ToString();
        }
        catch
        {
          nCounterValue.Text = string.Empty;
        }
      }
    }

    private void referenceFreq_TextChanged(object sender, EventArgs e)
    {
      if (!in_update)
      {
        in_update = true;
        if (referenceFreq.TextLength > 0 && FOSC.TextLength > 0)
          rCounterValue.Text = (int.Parse(FOSC.Text) / int.Parse(referenceFreq.Text)).ToString();
        else
          rCounterValue.Text = string.Empty;
        in_update = false;
      }
    }

    private void rCounterValue_TextChanged(object sender, EventArgs e)
    {
      out_freq_TextChanged(null, null);
      if (!in_update)
      {
        in_update = true;
        if (rCounterValue.TextLength > 0 && FOSC.TextLength > 0)
          referenceFreq.Text = (int.Parse(FOSC.Text) / int.Parse(rCounterValue.Text)).ToString();
        else
          referenceFreq.Text = string.Empty;
        in_update = false;
      }
    }

    private void bnSetRCounterWord_Click(object sender, EventArgs e)
    {
      cpl.Write(string.Format("pl{0:X6}\r", buildRCounterWord()));
      cpl.wait_OK();
    }

    private void bnSetControlWord_Click(object sender, EventArgs e)
    {
      cpl.Write(string.Format("pl{0:X6}\r", buildControlWord()));
      cpl.wait_OK();
    }

    private void nCounterValue_TextChanged(object sender, EventArgs e)
    {

    }

    private int buildControlWord()
    {
      int control_word = 0;

      if (bnAsyncPowerDown.Checked)
        control_word |= ad4360.ASYNCHRONOUS_POWER_DOWN;
      else if (bnSyncPowerDown.Checked)
        control_word |= ad4360.SYNCHRONOUS_POWER_DOWN;

      control_word |= corePowerLevel.SelectedIndex << ad4360.CORE_POWER_LEVEL;

      control_word |= currentSetting1.SelectedIndex << ad4360.CURRENT_SETTING_1;

      control_word |= currentSetting2.SelectedIndex << ad4360.CURRENT_SETTING_2;

      if (bnCurrentSetting2.Checked)
        control_word |= ad4360.CONTROL_LATCH_CP_GAIN_CURRENT_SETTING_2;

      if (bnCPThreeState.Checked)
        control_word |= ad4360.CHARGE_PUMP_OUTPUT_THREE_STATE;

      if (bnPhaseDetPolPos.Checked)
        control_word |= ad4360.PHASE_DETECTOR_POLARITY_POSITIVE;

      if (bnCounterReset.Checked)
        control_word |= ad4360.COUNTER_RESET;

      if (bnMuteTillLockDetect.Checked)
        control_word |= ad4360.MUTE_TIL_LOCK_DETECT;

      control_word |= outPowerLevel.SelectedIndex << ad4360.OUTPUT_POWER_LEVEL;

      control_word |= muxoutControl.SelectedIndex << ad4360.MUXOUT;

      control_word |= ad4360.CONTROL_LATCH;

      return control_word;
    }

    private int buildRCounterWord()
    {
      int r_counter_word = 0;

      r_counter_word |= bandSelClockDiv.SelectedIndex << ad4360.BAND_SELECT_CLOCK_DIVIDER;

      r_counter_word |= antiBLPW.SelectedIndex << ad4360.ANTI_BACKLASH_PULSE_WIDTH;

      if (bnFiveCycles.Checked)
        r_counter_word |= ad4360.LOCK_DETECT_PRECISION_FIVE_CYCLES;

      r_counter_word |= int.Parse(rCounterValue.Text) << ad4360.R_COUNTER;

      r_counter_word |= ad4360.R_COUNTER_LATCH;

      return r_counter_word;
    }

    private int buildNCounterWord()
    {
      int n_counter_word = 0;

      if (bnCurrentSetting2.Checked)
        n_counter_word |= ad4360.N_COUNTER_CP_GAIN_CURRENT_SETTING_2;

      n_counter_word |= int.Parse(nCounterValue.Text) << ad4360.B_COUNTER;

      n_counter_word |= ad4360.N_COUNTER_LATCH;

      return n_counter_word;
    }

    public void readSettings()
    {
      ad4360_configuration configData = ConfigurationManager.GetSection("ad4360_settings") as ad4360_configuration;

      if ((configData.control_word & ad4360.ASYNCHRONOUS_POWER_DOWN) != 0)
        bnAsyncPowerDown.Checked = true;
      else if ((configData.control_word & ad4360.SYNCHRONOUS_POWER_DOWN) != 0)
        bnSyncPowerDown.Checked = true;
      else
        bnPowerNormal.Checked = true;

      corePowerLevel.SelectedIndex = (configData.control_word >> ad4360.CORE_POWER_LEVEL) & ad4360.CORE_POWER_LEVEL_MASK;

      currentSetting1.SelectedIndex = (configData.control_word >> ad4360.CURRENT_SETTING_1) & ad4360.CURRENT_SETTING_MASK;

      currentSetting2.SelectedIndex = (configData.control_word >> ad4360.CURRENT_SETTING_2) & ad4360.CURRENT_SETTING_MASK;

      if ((configData.control_word & ad4360.CONTROL_LATCH_CP_GAIN_CURRENT_SETTING_2) != 0)
        bnCurrentSetting2.Checked = true;
      else
        bnCurrentSetting1.Checked = true;

      bnCPThreeState.Checked = (configData.control_word & ad4360.CHARGE_PUMP_OUTPUT_THREE_STATE) != 0;

      if ((configData.control_word & ad4360.PHASE_DETECTOR_POLARITY_POSITIVE) != 0)
        bnPhaseDetPolPos.Checked = true;
      else
        bnPhaseDetPolNeg.Checked = true;

      bnCounterReset.Checked = (configData.control_word & ad4360.COUNTER_RESET) != 0;

      bnMuteTillLockDetect.Checked = (configData.control_word & ad4360.MUTE_TIL_LOCK_DETECT) != 0;

      outPowerLevel.SelectedIndex = (configData.control_word >> ad4360.OUTPUT_POWER_LEVEL) & ad4360.OUTPUT_POWER_LEVEL_MASK;

      muxoutControl.SelectedIndex = (configData.control_word >> ad4360.MUXOUT) & ad4360.MUXOUT_MASK;

      bandSelClockDiv.SelectedIndex = (configData.r_counter_word >> ad4360.BAND_SELECT_CLOCK_DIVIDER) &
                                      ad4360.BAND_SELECT_CLOCK_DIVIDER_MASK;

      antiBLPW.SelectedIndex = (configData.r_counter_word >> ad4360.ANTI_BACKLASH_PULSE_WIDTH) &
                               ad4360.ANTI_BACKLASH_PULSE_WIDTH_MASK;

      if ((configData.r_counter_word & ad4360.LOCK_DETECT_PRECISION_FIVE_CYCLES) != 0)
        bnFiveCycles.Checked = true;
      else
        bnThreeCycles.Checked = true;

      rCounterValue.Text = ((configData.r_counter_word >> ad4360.R_COUNTER) & ((1 << ad4360.R_COUNTER_BITS) - 1)).ToString();

      nCounterValue.Text = ((configData.n_counter_word >> ad4360.B_COUNTER) & ((1 << ad4360.B_COUNTER_BITS) - 1)).ToString();
    }

    public void saveSettings()
    {
      ad4360_configuration cfg = new ad4360_configuration(buildControlWord(), buildNCounterWord(), buildRCounterWord());

      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      config.Sections.Remove("ad4360_settings");
      config.Sections.Add("ad4360_settings", cfg);
      config.Save(ConfigurationSaveMode.Full);
    }

    public void applySettings()
    {
      bnSetControlWord_Click(null, null);
      bnSetRCounterWord_Click(null, null);
      bnFreqSet_Click(null, null);
    }
  }

  public class ad4360_configuration : ConfigurationSection
  {
    public ad4360_configuration()
    {
    }

    public ad4360_configuration(int c, int n, int r)
    {
      this["control_word"] = c;
      this["n_counter_word"] = n;
      this["r_counter_word"] = r;
    }

    [ConfigurationProperty("control_word")]
    public int control_word
    {
      get { return (int)this["control_word"]; }
      set { this["control_word"] = value; }
    }

    [ConfigurationProperty("r_counter_word")]
    public int r_counter_word
    {
      get { return (int)this["r_counter_word"]; ; }
      set { this["r_counter_word"] = value; }
    }

    [ConfigurationProperty("n_counter_word")]
    public int n_counter_word
    {
      get { return (int)this["n_counter_word"]; ; }
      set { this["n_counter_word"] = value; }
    }
  }
}
