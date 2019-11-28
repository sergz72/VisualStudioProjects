namespace gen_freq_meter_level_meter
{
  public class LevelMeterBase
  {
    public readonly int MinLevel;
    public readonly int MaxLevel;
    private readonly double Offset;
    private readonly double Coef;

    public LevelMeterBase(int minLevel, int maxLevel, double offset, double coef)
    {
      MinLevel = minLevel;
      MaxLevel = maxLevel;
      Offset = offset;
      Coef = coef;
    }

    public double getLevel(uint mv)
    {
      return (mv - Offset) / Coef;
    }
  }
}
