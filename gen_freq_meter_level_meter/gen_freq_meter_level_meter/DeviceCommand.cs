using System;
using System.Text;

namespace gen_freq_meter_level_meter
{
  public interface ICommandHandler
  {
    bool CheckAnswer(DeviceCommand command, byte[] answer);
  }

  public class DeviceCommand
  {
    public readonly char command;
    public readonly byte? charParameter;
    public readonly ushort? shortParameter;
    public readonly uint[] intParameter;
    public readonly ICommandHandler handler;
    public readonly int answerBytes;

    public DeviceCommand(char c, byte? cp, ushort? sp, uint[] ip, ICommandHandler h, int ab)
    {
      command = c;
      charParameter = cp;
      shortParameter = sp;
      intParameter = ip;
      handler = h;
      answerBytes = ab;
    }

    public DeviceCommand(char c, ICommandHandler h, int ab)
    {
      command = c;
      charParameter = null;
      shortParameter = null;
      intParameter = null;
      handler = h;
      answerBytes = ab;
    }

    public DeviceCommand(char c, byte? cp, ICommandHandler h, int ab)
    {
      command = c;
      charParameter = cp;
      shortParameter = null;
      intParameter = null;
      handler = h;
      answerBytes = ab;
    }

    public DeviceCommand(char c, byte? cp, ushort? sp, ICommandHandler h, int ab)
    {
      command = c;
      charParameter = cp;
      shortParameter = sp;
      intParameter = null;
      handler = h;
      answerBytes = ab;
    }

    public int getBytes(byte[] buffer)
    {
      buffer[0] = (byte)command;
      if (charParameter == null)
        return 1;
      buffer[1] = (byte)charParameter.Value;
      if (shortParameter == null)
        return 2;
      byte[] bytes = BitConverter.GetBytes(shortParameter.Value);
      buffer[2] = bytes[0];
      buffer[3] = bytes[1];
      if (intParameter == null)
        return 4;
      int length = 4;
      foreach (uint value in intParameter)
      {
        bytes = BitConverter.GetBytes(value);
        buffer[length++] = bytes[0];
        buffer[length++] = bytes[1];
        buffer[length++] = bytes[2];
        buffer[length++] = bytes[3];
      }
      return length;
    }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.Append("command = ").Append(command).Append("\n");
      if (charParameter == null)
        return builder.ToString();
      builder.Append("charParameter = ").Append(charParameter).Append("\n");
      if (shortParameter == null)
        return builder.ToString();
      builder.Append("shortParameter = ").Append(shortParameter).Append("\n");
      if (intParameter == null)
        return builder.ToString();
      foreach (uint value in intParameter)
        builder.Append("intParameter = ").Append(value).Append("\n");
      return builder.ToString();
    }

    public bool CheckAnswer(byte[] answer)
    {
      return handler.CheckAnswer(this, answer);
    }
  }
}
