namespace WarpKez.ScaleModelling.MetricSystem;

public static partial class MetricConversion
{
    private static int decimalPrecision = 2;
    private static int inchPrecision = 64;

    // To prevent Integer Overflow when converting
    // decimal inches to frectional inches. 
    private static readonly int maxDecimalPlaces = 5;
    private static readonly int baseDenominator = (int)Math.Pow(10, maxDecimalPlaces);

    /// <summary>
    /// Sets/Gets the precision of inches /1 /2 /4 /8 /16 /32 /64 /128
    /// </summary>
    public static InchFractions InchPrecision
    {
        get { return (InchFractions)inchPrecision; }
        set
        {
            inchPrecision = (int)InchPrecision;
        }
    }

    /// <summary>
    /// Sets/Gets the decimal precision required for the metric measurements.  Default is 2 decimal places, max is 5.
    /// </summary>
    public static int DecimalPrecision
    {
        get { return decimalPrecision; }
        set
        {
            if (value > 5) { value = maxDecimalPlaces; }
            if (value < 0) { value *= -1; }
            decimalPrecision = value;
        }
    }

    /// <summary>
    /// Quick metric conversion macros
    /// </summary>
    public static double FeetToMillimeters(double feet) => Math.Round(FeetToInches(feet) * 25.4, DecimalPrecision);
    public static double FeetToInches(double Feet) => Math.Round((Feet * 12.0), DecimalPrecision);
    public static double YardToFeet(double Yard) => Math.Round(Yard * 3, DecimalPrecision);
    public static double InchesToMillimeters(double Inches) => Math.Round((Inches * 25.4), DecimalPrecision);

    public static double MetersToMillimeters(double Meters) => Math.Round((Meters * 1000), DecimalPrecision);
    public static double CentimetersToMillimeters(double Centimeters) => Math.Round((Centimeters * 10), DecimalPrecision);
    public static double MillimetersToCentimeters(double Millmeters) => Math.Round((Millmeters / 10), DecimalPrecision);
    public static double MillimetersToMeters(double Millmeters) => Math.Round(MillimetersToCentimeters(Millmeters) / 100, DecimalPrecision);

    public static double MetersToFeet(double Meters) => Math.Round(Meters * 3.28084, DecimalPrecision);
    public static double CentimetersToInches(double Centimeters) => Math.Round(Centimeters / 2.54, DecimalPrecision);
    public static double MillimetersToInches(double Millmeters) => Math.Round(Millmeters / 25.4, DecimalPrecision);

    /// <summary>
    /// Returns the closest inch fractions above and below the provided value.
    /// </summary>
    /// <param name="DecimalInches"></param>
    /// <returns></returns>
    public static ImperialClosestFractionModel ClosestInchAsFraction(decimal DecimalInches)
    {
        if (DecimalInches < 0) { DecimalInches *= -1; }
        return ClosestInchAsFractionWorker(DecimalInches);
    }

    /// <summary>
    /// Returns the closest inch fractions above and below the provided value.
    /// </summary>
    /// <param name="Inch"></param>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public static ImperialClosestFractionModel ClosestInchesAsFraction(int Inch, int Numerator, int Denominator)
    {
        if (Inch < 0)
            Inch *= -1;
        if (Denominator < 0)
            Denominator *= -1;
        if (Numerator < 0)
            Numerator *= -1;
        if (Denominator == 0)
            throw new DivideByZeroException();

        decimal DecimalInches = (decimal)Inch + ((decimal)Numerator / (decimal)Denominator);
        return ClosestInchAsFractionWorker(DecimalInches);
    }
}
