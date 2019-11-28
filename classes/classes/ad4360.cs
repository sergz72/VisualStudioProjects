using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace classes
{
  public class ad4360
  {
    // latch types
    public const int CONTROL_LATCH = 0;
    public const int R_COUNTER_LATCH = 1;
    public const int N_COUNTER_LATCH = 2;
    // control latch constants
    public const int ASYNCHRONOUS_POWER_DOWN = 0x100000;
    public const int SYNCHRONOUS_POWER_DOWN  = 0x200000;
    public const int CURRENT_SETTING_2 = 17;
    public const int CURRENT_SETTING_1 = 14;
    public const int CURRENT_SETTING_MASK = 7;
    public const double ICP_STEP = 0.31;
    public const int ICP_STEP_COUNT = 8;
    public string[] OUTPUT_POWER_LEVELS;
    public const int OUTPUT_POWER_LEVEL = 12;
    public const int OUTPUT_POWER_LEVEL_MASK = 3;
    public const int MUTE_TIL_LOCK_DETECT = 0x800;
    public const int CONTROL_LATCH_CP_GAIN_CURRENT_SETTING_1 = 0;
    public const int CONTROL_LATCH_CP_GAIN_CURRENT_SETTING_2 = 0x400;
    public const int CHARGE_PUMP_OUTPUT_THREE_STATE = 0x200;
    public const int CHARGE_PUMP_OUTPUT_NORMAL = 0;
    public const int PHASE_DETECTOR_POLARITY_POSITIVE = 0x100;
    public const int PHASE_DETECTOR_POLARITY_NEGATIVE = 0;
    public const int MUXOUT = 5;
    public const int MUXOUT_MASK = 7;
    public string[] MUXOUT_VALUES;
    public const int COUNTER_OPERATION_NORMAL = 0;
    public const int COUNTER_RESET = 0x10;
    public string[] CORE_POWER_LEVELS;
    public const int CORE_POWER_LEVEL = 2;
    public const int CORE_POWER_LEVEL_MASK = 3;
    // N counter latch constants
    public const int N_COUNTER_CP_GAIN_CURRENT_SETTING_1 = 0;
    public const int N_COUNTER_CP_GAIN_CURRENT_SETTING_2 = 0x200000;
    public const int B_COUNTER = 8;
    public const int B_COUNTER_BITS = 13;
    public const int B_COUNTER_MIN_VALUE = 3;
    // R counter latch constants
    public const int BAND_SELECT_CLOCK_DIVIDER = 20;
    public const int BAND_SELECT_CLOCK_DIVIDER_MASK = 3;
    public string[] BAND_SELECT_CLOCK_DIVIDERS;
    public const int LOCK_DETECT_PRECISION_THREE_CYCLES = 0;
    public const int LOCK_DETECT_PRECISION_FIVE_CYCLES = 0x040000;
    public const int ANTI_BACKLASH_PULSE_WIDTH = 16;
    public const int ANTI_BACKLASH_PULSE_WIDTH_MASK = 3;
    public string[] ANTI_BACKLASH_PULSE_WIDTHS;
    public const int R_COUNTER = 2;
    public const int R_COUNTER_BITS = 14;
    public const int R_COUNTER_MIN_VALUE = 1;

    public int FOSC;
    public int CORE_POWER_LEVEL_DEFAULT;

    public ad4360(int fosc)
    {
      CORE_POWER_LEVELS = new string[] { "2.5 mA", "5 mA", "7.5 mA", "10 mA" };
      OUTPUT_POWER_LEVELS = new string[] { "-9(-19)dBm", "-6(-15)dBm", "-3(-12)dBm", "0(-9)dBm" };
      MUXOUT_VALUES = new string[] {
        "THREE-STATE",
        "DIGITAL LOCK DETECT",
        "N DIVIDER OUTPUT",
        "DVDD",
        "R DIVIDER OUTPUT",
        "NOT USED",
        "NOT USED",
        "DGND"
      };
      BAND_SELECT_CLOCK_DIVIDERS = new string[] { "1", "2", "4", "8" };
      ANTI_BACKLASH_PULSE_WIDTHS = new string[] { "0 - 3.0 ns", "1 - 1.3 ns", "2 - 6.0 ns", "3 - 3.0 ns" };

      CORE_POWER_LEVEL_DEFAULT = 1;

      FOSC = fosc;
    }

    public int calculate_n_counter_value(int freq, int r_counter_value)
    {
      int FREF = FOSC / r_counter_value;
      int n_counter_value = freq / FREF;
      if (n_counter_value < B_COUNTER_MIN_VALUE || n_counter_value >= 1 << B_COUNTER_BITS)
        throw new Exception("Invalid N counter value: " + n_counter_value.ToString());
      return n_counter_value;
    }
  }
}