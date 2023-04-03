using System;

namespace classes
{
  public class i2c_device
  {
    protected byte device_address;

    protected void Write(i2c i, params byte[] data)
    {
      i.Write(device_address, data);
    }
  }
}
