using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gen_freq_meter_level_meter
{
  public abstract class GeneratorOutput
  {
    public readonly int MinLevel;
    public readonly int MaxLevel;
    public readonly SignalForm[] SupportedSignalForms;
    public bool IsEnabled { get; set; }

    public GeneratorOutput(int minLevel, int maxLevel, SignalForm[] supportedSignalForms)
    {
      MinLevel = minLevel;
      MaxLevel = maxLevel;
      SupportedSignalForms = supportedSignalForms;
      IsEnabled = false;
    }

    public abstract uint CalculateLevelCode(int level);
  }
}
