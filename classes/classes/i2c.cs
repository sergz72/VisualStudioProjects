using System;

namespace classes
{
  public interface i2c
  {
    void Write(byte Address, params byte[] data);
    void RawWrite(string s);
  }
}
