using System;
using System.Threading;

namespace classes
{
  public class cdce913: i2c_device
  {
    protected int n, pdiv, m, f_vco, f_osc;
    protected int f_vco_max, f_vco_min;
    protected bool block_mode;
    protected byte[] registers;

    public cdce913(int fosc)
    {
      f_osc = fosc;
      device_address = 0xCA;
      f_vco_max = 200000;
      f_vco_min = 100000;
      block_mode = false;
      registers = new byte[0x21];

      ResetRegisters();
    }

    protected void ResetRegisters()
    {
      registers[0] = 0;
      
      registers[1] = 0;
      registers[2] = 1;
      registers[3] = 0xB4;
      registers[4] = 0;
      registers[5] = 2;
      registers[6] = 0x50;
      registers[7] = 0x40;
      registers[8] = registers[9] = registers[0x0A] = registers[0x0B] = registers[0x0C] =
                     registers[0x0D] = registers[0x0E] = registers[0x0F] = registers[0x10] = 0;
      
      registers[0x11] = 0;
      registers[0x12] = 0;
      registers[0x13] = 0;
      registers[0x14] = 0;
      registers[0x15] = 0xED;
      registers[0x16] = 2;
      registers[0x17] = 1;
      registers[0x18] = 1;
      registers[0x19] = 0;
      registers[0x1A] = 0x40;
      registers[0x1B] = 2;
      registers[0x1C] = 8;
      registers[0x1D] = 0;
      registers[0x1E] = 0x40;
      registers[0x1F] = 2;
      registers[0x20] = 8;
    }

    public void set_fosc(int fosc)
    {
      f_osc = fosc;
    }

    public int get_y1_pdiv()
    {
      return pdiv;
    }

    public void Write_byte(i2c i, byte Command, byte Data)
    {
      if (block_mode)
        registers[Command+1] = Data;
      else
      {
        Command |= 0x80;
        Write(i, Command, Data);
      }
    }

    protected void Flush(i2c i)
    {
      if (block_mode)
        Write(i, registers);
    }

    public void init(i2c i)
    {
      Write_byte(i, 2, 0xB8); // Y1_ST1 - Y1 enabled, Y1_ST0 - Y1 disabled to low
//      Write_byte(i, 0x13, 0); // PLL1 Frequency Selection: predefined by PLL1_0 – Multiplier/Divider value
      // PLL1 Multiplexer: PLL1,
      // Output Y2 Multiplexer: Pdiv2
      // Output Y3 Multiplexer: Pdiv3-Divider
      // Y2Y3_ST1 - Y2/Y3 enabled, Y2Y3_ST0 - Y2/Y3 disabled to low
//      Write_byte(i, 0x14, 0x6E);
      y2y3_off(i);
    }

    public void set_y1_freq(i2c i, int freq)
    {
      i.RawWrite("cd");
      Thread.Sleep(250);
      i.RawWrite("cu");
//      Write_byte(i, 0x13, 0); // PLL1 Frequency Selection: predefined by PLL1_0 – Multiplier/Divider value

      int p, n1, q, r;

      calc_koefs(freq);

      Write_byte(i, 0x03, (byte)pdiv);

      p = 4 - (int)(Math.Log(n / m) / Math.Log(2));
      if (p < 0) p = 0;

      n1 = n << p;

      q = n1 / m;

      r = n1 - m * q;

      byte b;

      b = (byte)(n >> 4);
      Write_byte(i, 0x18, b);

      b = (byte)(((n & 0x0f) << 4) | (r >> 5));
      Write_byte(i, 0x19, b);

      b = (byte)(((r & 0x1f) << 3) | (q >> 3));
      Write_byte(i, 0x1A, b);

      if (f_vco < 125000)
        b = 0;
      else if (f_vco < 150000)
        b = 1;
      else if (f_vco < 175000)
        b = 2;
      else
        b = 3;

      b |= (byte)(((q & 7) << 5) | (p << 2));
      Write_byte(i, 0x1B, b);

//      Write_byte(i, 0x13, 1); // PLL1 Frequency Selection: predefined by PLL1_1 – Multiplier/Divider value

//      Write_byte(i, 0x14, 0x6D);
        Write_byte(i, 0x14, 0x6E);

      Flush(i);
    }

    public void set_y2_div(i2c i, byte div)
    {
      div &= 0x7f;
      Write_byte(i, 0x16, div);
    }

    public void set_y3_div(i2c i, byte div)
    {
      div &= 0x7f;
      Write_byte(i, 0x17, div);
    }

    public void y1_on(i2c i)
    {
      Write_byte(i, 4, 2);
    }

    public void y1_off(i2c i)
    {
      Write_byte(i, 4, 1);
    }

    public void y2y3_on(i2c i)
    {
      Write_byte(i, 0x15, 2);
    }

    public void y2y3_off(i2c i)
    {
      Write_byte(i, 0x15, 1);
    }

    public void eeprom_write(i2c i)
    {
      Write_byte(i, 6, 0x41);
    }

    protected void calc_koefs(int freq)
    {
      pdiv = 200000 / freq;
      int k = 1;
      while (pdiv > k)
        k <<= 1;
      pdiv = k;

      m = 511;

      n = freq * pdiv * m / f_osc;

      f_vco = f_osc * n / m;

      if (f_vco > f_vco_max)
      {
        pdiv >>= 1;
        f_vco >>= 1;
        n >>= 1;
      }
      else if (f_vco < f_vco_min)
      {
        pdiv <<= 1;
        f_vco <<= 1;
        n <<= 1;
      }

      if ((f_vco > f_vco_max) || (f_vco < f_vco_min) || (n > 4095) || (pdiv > 127) || (pdiv < 1) || (n < 1) || (n < m))
        throw new ArgumentOutOfRangeException();
    }
  }
}
