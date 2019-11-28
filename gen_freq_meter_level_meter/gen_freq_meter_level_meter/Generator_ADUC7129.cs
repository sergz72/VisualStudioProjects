using System;
using System.Collections.Generic;

namespace gen_freq_meter_level_meter
{
  public class ADUC7129_Output: GeneratorOutput
  {
    public ADUC7129_Output(): base(-16, 2, new SignalForm[] { SignalForm.Sine })
    {
    }

    public override uint CalculateLevelCode(int level)
    {
      uint scale = (ushort)(6.355 * Math.Pow(10, 0.05 * level));
      if (scale == 0)
        scale = 1;
      else if (scale > 8)
        scale = 8;
      return scale;
    }
  }

  public class Generator_ADUC7129 : GeneratorBase, ICommandHandler
  {
    private ushort levelCode;
    private uint frequencyCode;

    public Generator_ADUC7129(Queue<DeviceCommand> _nextCommands, int correction) : base(_nextCommands, correction, new GeneratorOutput[] { new ADUC7129_Output() })
    {
      levelCode = 8;
      frequencyCode = 1;
    }

    public override uint MaxFrequency
    {
      get
      {
        return 20889600;
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
        nextCommands.Enqueue(new DeviceCommand('D', 0, levelCode, intp, this, 1));
      }
      else
      {
        intp[0] = 0;
        nextCommands.Enqueue(new DeviceCommand('D', 0, 0, intp, this, 1));
      }
      return true;
    }

    private uint CalculateFrequencyCode(uint frequency)
    {
      return (uint)(0x100000000 * frequency / MaxFrequency);
    }

    protected override void _SetFrequency(uint frequency)
    {
      frequencyCode = CalculateFrequencyCode(frequency);
      if (Outputs[0].IsEnabled && nextCommands != null)
      {
        uint[] intp = new uint[1];
        intp[0] = frequencyCode;
        nextCommands.Enqueue(new DeviceCommand('D', 0, levelCode, intp, this, 1));
      }
    }

    protected override void _SetLevel(int outputNo, int level)
    {
      levelCode = (ushort)Outputs[outputNo].CalculateLevelCode(level);
      if (Outputs[0].IsEnabled && nextCommands != null)
      {
        uint[] intp = new uint[1];
        intp[0] = frequencyCode;
        nextCommands.Enqueue(new DeviceCommand('D', 0, levelCode, intp, this, 1));
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
