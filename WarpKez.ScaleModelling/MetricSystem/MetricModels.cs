using WarpKez.ScaleModelling.FractionMathematics;

namespace WarpKez.ScaleModelling.MetricSystem;

public enum InchFractions
{
    One = 1,
    Half = 2,
    Quarter = 4,
    Eight = 8,
    Sixteenth = 16,
    ThirtySecond = 32,
    SixtyForth = 64
}

public enum Metrics
{
    Yards, Feet, Inches, Metres, Centimetres, Millimetres
}

public class ImperialMeasurementModel
{
    public int Yards { get; set; } = 0;
    public int Feet { get; set; } = 0;
    public int Inches { get; set; } = 0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public ImperialClosestFractionModel? ClosestFraction { get; set; }
}

public class ImperialClosestFractionModel
{
    public FractionImproperModel? LowerCommonFraction { get; set; }
    public double LowerInchDecimal { get; set; } = 0.0;
    public FractionImproperModel? InchAsFraction { get; set; }
    public double InchesAsDecimal { get; set; } = 0.0;
    public FractionImproperModel? UpperCommonFraction { get; set; }
    public double UpperInchDecimal { get; set; } = 0.0;
}

public class ImperialInchModel
{
    public int Inch { get; set; } = 0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set;} = 0;
}
