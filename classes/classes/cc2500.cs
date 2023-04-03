using System;

namespace classes
{
  public class cc2500
  {
    protected static int[][] init_cfg250 = {
//      new int[2] { 0x00, 0x06 }, // IOCFG2
      new int[2] { 0x02, 0x06 }, // IOCFG0
      new int[2] { 0x08, 0x45 }, // PKTCTRL0
//      new int[2] { 0x0B, 0x0A }, // FSCTRL1
      new int[2] { 0x0B, 0x09 }, // FSCTRL1
      new int[2] { 0x0C, 0x00 }, // FSCTRL0
      new int[2] { 0x0D, 0x5D }, // FREQ2
      new int[2] { 0x0E, 0x93 }, // FREQ1
      new int[2] { 0x0F, 0xB1 }, // FREQ0
      new int[2] { 0x10, 0x2D }, // MDMCFG4
      new int[2] { 0x11, 0x3B }, // MDMCFG3
      new int[2] { 0x12, 0x73 }, // MDMCFG2
      new int[2] { 0x13, 0x22 }, // MDMCFG1
      new int[2] { 0x14, 0xF8 }, // MDMCFG0
      new int[2] { 0x15, 0x01 }, // DEVIATN
//      new int[2] { 0x15, 0x00 }, // DEVIATN
      new int[2] { 0x18, 0x18 }, // MCSM0
      new int[2] { 0x19, 0x1D }, // FOCCFG
      new int[2] { 0x1A, 0x1C }, // BSCFG
      new int[2] { 0x1B, 0xC7 }, // AGCCTRL2
      new int[2] { 0x1C, 0x00 }, // AGCCTRL1
//      new int[2] { 0x1D, 0xB0 }, // AGCCTRL0
      new int[2] { 0x1D, 0xB2 }, // AGCCTRL0
      new int[2] { 0x21, 0xB6 }, // FREND1
      new int[2] { 0x22, 0x10 }, // FREND0
      new int[2] { 0x23, 0xEA }, // FSCAL3
      new int[2] { 0x24, 0x0A }, // FSCAL2
      new int[2] { 0x25, 0x00 }, // FSCAL1
      new int[2] { 0x26, 0x11 }, // FSCAL0
      new int[2] { 0x29, 0x59 }, // FSTEST
      new int[2] { 0x2C, 0x88 }, // TEST2
      new int[2] { 0x2D, 0x31 }, // TEST1
      new int[2] { 0x2E, 0x0B }, // TEST0
    };

    protected static int[][] init_cfg2 = {
      new int[2] { 0x02, 0x06 }, // IOCFG0
      new int[2] { 0x08, 0x45 }, // PKTCTRL0
//      new int[2] { 0x08, 0x05 }, // PKTCTRL0
      new int[2] { 0x0B, 0x08 }, // FSCTRL1
      new int[2] { 0x0C, 0x00 }, // FSCTRL0
      new int[2] { 0x0D, 0x5D }, // FREQ2
      new int[2] { 0x0E, 0x93 }, // FREQ1
      new int[2] { 0x0F, 0xB1 }, // FREQ0
      new int[2] { 0x10, 0x86 }, // MDMCFG4
      new int[2] { 0x11, 0x83 }, // MDMCFG3
//      new int[2] { 0x12, 0x03 }, // MDMCFG2
      new int[2] { 0x12, 0x01 }, // MDMCFG2
      new int[2] { 0x13, 0x22 }, // MDMCFG1
//      new int[2] { 0x13, 0x72 }, // MDMCFG1
      new int[2] { 0x14, 0xF8 }, // MDMCFG0
      new int[2] { 0x15, 0x44 }, // DEVIATN
//      new int[2] { 0x15, 0x74 }, // DEVIATN
      new int[2] { 0x18, 0x18 }, // MCSM0
      new int[2] { 0x19, 0x16 }, // FOCCFG
      new int[2] { 0x1A, 0x6C }, // BSCFG
      new int[2] { 0x1B, 0x03 }, // AGCCTRL2
      new int[2] { 0x1C, 0x40 }, // AGCCTRL1
      new int[2] { 0x1D, 0x91 }, // AGCCTRL0
      new int[2] { 0x21, 0x56 }, // FREND1
      new int[2] { 0x22, 0x10 }, // FREND0
      new int[2] { 0x23, 0xA9 }, // FSCAL3
      new int[2] { 0x24, 0x0A }, // FSCAL2
      new int[2] { 0x25, 0x00 }, // FSCAL1
      new int[2] { 0x26, 0x11 }, // FSCAL0
      new int[2] { 0x29, 0x59 }, // FSTEST
      new int[2] { 0x2C, 0x88 }, // TEST2
      new int[2] { 0x2D, 0x31 }, // TEST1
      new int[2] { 0x2E, 0x0B }, // TEST0
    };

    protected static int[][] init_cfg10 = {
      new int[2] { 0x02, 0x06 }, // IOCFG0
      new int[2] { 0x08, 0x45 }, // PKTCTRL0
      new int[2] { 0x0B, 0x06 }, // FSCTRL1
      new int[2] { 0x0C, 0x00 }, // FSCTRL0
      new int[2] { 0x0D, 0x5D }, // FREQ2
      new int[2] { 0x0E, 0x93 }, // FREQ1
      new int[2] { 0x0F, 0xB1 }, // FREQ0
      new int[2] { 0x10, 0x78 }, // MDMCFG4
      new int[2] { 0x11, 0x93 }, // MDMCFG3
      new int[2] { 0x12, 0x03 }, // MDMCFG2
      new int[2] { 0x13, 0x22 }, // MDMCFG1
      new int[2] { 0x14, 0xF8 }, // MDMCFG0
      new int[2] { 0x15, 0x44 }, // DEVIATN
      new int[2] { 0x18, 0x18 }, // MCSM0
      new int[2] { 0x19, 0x16 }, // FOCCFG
      new int[2] { 0x1A, 0x6C }, // BSCFG
      new int[2] { 0x1B, 0x43 }, // AGCCTRL2
      new int[2] { 0x1C, 0x40 }, // AGCCTRL1
      new int[2] { 0x1D, 0x91 }, // AGCCTRL0
      new int[2] { 0x21, 0x56 }, // FREND1
      new int[2] { 0x22, 0x10 }, // FREND0
      new int[2] { 0x23, 0xA9 }, // FSCAL3
      new int[2] { 0x24, 0x0A }, // FSCAL2
      new int[2] { 0x25, 0x00 }, // FSCAL1
      new int[2] { 0x26, 0x11 }, // FSCAL0
      new int[2] { 0x29, 0x59 }, // FSTEST
      new int[2] { 0x2C, 0x88 }, // TEST2
      new int[2] { 0x2D, 0x31 }, // TEST1
      new int[2] { 0x2E, 0x0B }, // TEST0
    };

    protected static int[][] init_cfg500 = {
      new int[2] { 0x02, 0x06 }, // IOCFG0
      new int[2] { 0x08, 0x45 }, // PKTCTRL0
      new int[2] { 0x0B, 0x10 }, // FSCTRL1
      new int[2] { 0x0C, 0x00 }, // FSCTRL0
      new int[2] { 0x0D, 0x5D }, // FREQ2
      new int[2] { 0x0E, 0x93 }, // FREQ1
      new int[2] { 0x0F, 0xB1 }, // FREQ0
      new int[2] { 0x10, 0x0E }, // MDMCFG4
      new int[2] { 0x11, 0x3B }, // MDMCFG3
      new int[2] { 0x12, 0x73 }, // MDMCFG2
      new int[2] { 0x13, 0x42 }, // MDMCFG1
      new int[2] { 0x14, 0xF8 }, // MDMCFG0
      new int[2] { 0x15, 0x00 }, // DEVIATN
      new int[2] { 0x18, 0x18 }, // MCSM0
      new int[2] { 0x19, 0x1D }, // FOCCFG
      new int[2] { 0x1A, 0x1C }, // BSCFG
      new int[2] { 0x1B, 0xC7 }, // AGCCTRL2
      new int[2] { 0x1C, 0x40 }, // AGCCTRL1
      new int[2] { 0x1D, 0xB0 }, // AGCCTRL0
      new int[2] { 0x21, 0xB6 }, // FREND1
      new int[2] { 0x22, 0x10 }, // FREND0
      new int[2] { 0x23, 0xEA }, // FSCAL3
      new int[2] { 0x24, 0x0A }, // FSCAL2
      new int[2] { 0x25, 0x00 }, // FSCAL1
      new int[2] { 0x26, 0x19 }, // FSCAL0
      new int[2] { 0x29, 0x59 }, // FSTEST
      new int[2] { 0x2C, 0x88 }, // TEST2
      new int[2] { 0x2D, 0x31 }, // TEST1
      new int[2] { 0x2E, 0x0B }, // TEST0
    };

    protected static string[] power_level_strings = {
      "-30", "-28", "-26", "-24", "-22", "-20", "-18", "-16",
      "-14", "-12", "-10",  "-8",  "-6",  "-4",  "-2",   "0",
      "+1"
    };

    public static string[] data_rates = {
      "2.4", "10", "250", "500"
    };

    protected static int[] power_level_values = {
      0x50, 0x44, 0xC0, 0x84, 0x81, 0x46, 0x93, 0x55,
      0x8D, 0xC6, 0x97, 0x6E, 0x7F, 0xA9, 0xBB, 0xFE,
      0xFF
    };

    public bool CRC_AUTOFLUSH, ManchesterEnable;
    public int AddressCheck, PacketLength, ChannelNo, DeviceAddress, RXOFF_MODE, TXOFF_MODE, CCA_MODE;
    public int output_power_level, data_rate;

    protected CommPortLogged cpl;

    public cc2500(CommPortLogged c)
    {
      cpl = c;

      CRC_AUTOFLUSH = ManchesterEnable = false;
      AddressCheck = ChannelNo = DeviceAddress = RXOFF_MODE = TXOFF_MODE = CCA_MODE = 0;
      PacketLength = 61;
      output_power_level = 0;
    }

    public void Reset()
    {
      cpl.Write("rs\r");
      cpl.get_responce();
    }

    public void WriteByte(int register_id, int data)
    {
      cpl.Write(string.Format("wb{0:X2}{1:X2}\r", register_id, data));
      cpl.get_responce();
    }

    public void Init()
    {
      int[][] dr;

      if (data_rate == 0)
        dr = init_cfg2;
      else if (data_rate == 1)
        dr = init_cfg10;
      else if (data_rate == 2)
        dr = init_cfg250;
      else
        dr = init_cfg500;

      foreach (int[] val in dr)
        WriteByte(val[0], val[1]);

      WriteByte(0x06, PacketLength);  // PKTLEN

      int code = 4; // APPEND_STATUS
      if (CRC_AUTOFLUSH)
        code |= 8; // CRC_AUTOFLUSH
      code |= AddressCheck;
      WriteByte(0x07, code); // PKTCTRL1

      WriteByte(0x09, DeviceAddress); // ADDR
      WriteByte(0x0A, ChannelNo);     // CHANNR

      code = (CCA_MODE << 4) | (RXOFF_MODE << 2) | TXOFF_MODE;
      WriteByte(0x17, code); // MCSM1

      setOutputPowerLevel();
    }

    public static string[] getOutputPowerLevels()
    {
      return power_level_strings;
    }

    protected void setOutputPowerLevel()
    {
      int code = 0;

      for (int i = 0; i < power_level_values.Length; i++)
      {
        if (int.Parse(power_level_strings[i]) >= output_power_level)
        {
          code = power_level_values[i];
          break;
        }
      }

      cpl.Write(string.Format("wp{0:X2}\r", code));
      cpl.get_responce();
    }

    public void RxModeOn()
    {
      cpl.Write("e\r");
      cpl.get_responce();
      cpl.Write("c34\r");
      cpl.get_responce();
    }

    public void Transmit(int dest_device_address, string text)
    {
      cpl.Write(string.Format("t{0:x2}{1}\r", dest_device_address, text));
    }
  }
}
