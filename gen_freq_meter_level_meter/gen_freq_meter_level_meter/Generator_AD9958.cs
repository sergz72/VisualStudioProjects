using System;
using System.Collections.Generic;

namespace gen_freq_meter_level_meter
{
  public class AD9958_Output : GeneratorOutput
  {
    public AD9958_Output() : base(-75, -15, new SignalForm[] { SignalForm.Sine })
    {
    }

    public override uint CalculateLevelCode(int level)
    {
      ushort scale = (ushort)(5752.76 * Math.Pow(10, 0.05 * level));
      if (scale == 0)
        scale = 1;
      else if (scale > 1023)
        scale = 1023;
      return scale;
    }

  }

  public class Generator_AD9958 : GeneratorBase, ICommandHandler
  {
    private byte channelNo;
    private ushort levelCode;
    private uint frequencyCode;

    public Generator_AD9958(Queue<DeviceCommand> _nextCommands, int correction, byte channel): base(_nextCommands, correction, new GeneratorOutput[] { new AD9958_Output() })
    {
      levelCode = 1023;
      frequencyCode = 0;
      channelNo = (byte)(channel + 1);
    }

    public override uint MaxFrequency
    {
      get
      {
        return 200000000;
      }
    }

    public override uint MinFrequency
    {
      get
      {
        return 1;
      }
    }

    public override bool OutputEnable(int outputNo, bool enable)
    {
      Outputs[outputNo].IsEnabled = enable;
      if (nextCommands == null)
        return true;
      uint[] intp = new uint[1];
      if (enable)
      {
        intp[0] = frequencyCode;
        nextCommands.Enqueue(new DeviceCommand('D', channelNo, levelCode, intp, this, 1));
      }
      else
      {
        intp[0] = 0;
        nextCommands.Enqueue(new DeviceCommand('D', channelNo, 0, intp, this, 1));
      }
      return true;
    }

    private uint CalculateFrequencyCode(uint frequency)
    {
      return (uint)(0x100000000 * frequency / 500000000);
    }

    protected override void _SetFrequency(uint frequency)
    {
      frequencyCode = CalculateFrequencyCode(frequency);
      if (Outputs[0].IsEnabled && nextCommands != null)
      {
        uint[] intp = new uint[1];
        intp[0] = frequencyCode;
        nextCommands.Enqueue(new DeviceCommand('D', channelNo, levelCode, intp, this, 1));
      }
    }

    protected override void _SetLevel(int outputNo, int level)
    {
      levelCode = (ushort)Outputs[outputNo].CalculateLevelCode(level);
      if (Outputs[0].IsEnabled && nextCommands != null)
      {
        uint[] intp = new uint[1];
        intp[0] = frequencyCode;
        nextCommands.Enqueue(new DeviceCommand('D', channelNo, levelCode, intp, this, 1));
      }
    }

    protected override void _SetSignalForm(int outputNo, SignalForm form)
    {
    }

    public bool CheckAnswer(DeviceCommand command, byte[] answer)
    {
      return answer[0] == (byte)'k';
    }
  }
}
