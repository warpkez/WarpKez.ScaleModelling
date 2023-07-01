namespace WarpKez.ScaleModelling.FractionMathematics;

/// <summary>
/// Model for Improper or Mixed fractions consisting of Unit and Numerator/Denominator
/// </summary>
public class FractionImproperModel
{
    public int Unit { get; set; } = 0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Basic model for fractions consisting of a Numerator/Denominator
/// </summary>
public class FractionModel
{
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public string Message { get; set; } = string.Empty;
}