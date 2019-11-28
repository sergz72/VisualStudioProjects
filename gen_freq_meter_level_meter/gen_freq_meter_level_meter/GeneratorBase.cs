using System;
using System.Collections.Generic;

namespace gen_freq_meter_level_meter
{
  public enum SignalForm { Sine, Square, Triangle }

  public abstract class GeneratorBase
  {
    public readonly long Correction;
    public readonly GeneratorOutput[] Outputs;
    public abstract uint MinFrequency { get; }
    public abstract uint MaxFrequency { get; }
    protected readonly Queue<DeviceCommand> nextCommands;

    protected GeneratorBase(Queue<DeviceCommand> _nextCommands, int correction, GeneratorOutput[] outputs)
    {
      Correction = correction;
      nextCommands = _nextCommands;
      Outputs = outputs;
    }

    public bool SetFrequency(uint frequency)
    {
      if (frequency < MinFrequency || frequency > MaxFrequency)
        return false;

      if (Correction != 0)
      {
        if (Correction > 0)
          frequency += (uint)((long)frequency * Correction / 10000000);
        else
          frequency -= (uint)((long)frequency * -Correction / 10000000);
      }

      _SetFrequency(frequency);

      return true;
    }

    protected abstract void _SetFrequency(uint frequency);

    public bool SetLevel(int outputNo, int level)
    {
      if (outputNo >= Outputs.Length || outputNo < 0 || level < Outputs[outputNo].MinLevel || level > Outputs[outputNo].MaxLevel)
        return false;

      _SetLevel(outputNo, level);

      return true;
    }

    protected abstract void _SetLevel(int outputNo, int level);
    public abstract bool OutputEnable(int outputNo, bool enable);

    public bool SetSignalForm(int outputNo, SignalForm form)
    {
      if (outputNo < 0 || outputNo >= Outputs.Length || Array.IndexOf(Outputs[outputNo].SupportedSignalForms, form) == -1)
        return false;

      _SetSignalForm(outputNo, form);

      return true;
    }

    protected abstract void _SetSignalForm(int outputNo, SignalForm form);
  }
}
