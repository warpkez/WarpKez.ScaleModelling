namespace WarpKez.ScaleModelling.TrigMathematics;

public static partial class Trigonometry
{
    private static int decimalPrecision = 2;
    private static readonly int maxDecimalPlaces = 5;

    /// <summary>
    /// Sets/Gets the decimal precision required for the metric measurements.  Default is 2 decimal places, max is 5.
    /// *** Not impletemented as yet ***
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
    /// Find the length of the Opposite side
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Adjacent"></param>
    /// <returns></returns>
    public static double Opposite(double Hypotenuse, double Adjacent) => Math.Sqrt((Hypotenuse * Hypotenuse) - (Adjacent * Adjacent));

    /// <summary>
    /// Find the length of the Hypotenuse
    /// </summary>
    /// <param name="Opposite"></param>
    /// <param name="Adjacent"></param>
    /// <returns></returns>
    public static double Hypotenuse(double Opposite, double Adjacent) => Math.Sqrt((Opposite * Opposite) + (Adjacent * Adjacent));

    /// <summary>
    /// Find the length of the Adjacent side
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Opposite"></param>
    /// <returns></returns>
    public static double Adjacent(double Hypotenuse, double Opposite) => Math.Sqrt((Hypotenuse * Hypotenuse) - (Opposite * Opposite));

    /// <summary>
    /// SinA
    /// </summary>
    /// <param name="Opposite"></param>
    /// <param name="Hypotenuse"></param>
    /// <returns></returns>
    public static double SinA(double Opposite, double Hypotenuse) => Opposite / Hypotenuse;

    /// <summary>
    /// Cosecant A 1/sin(A)
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Opposite"></param>
    /// <returns></returns>
    public static double CosecantA(double Hypotenuse, double Opposite) => Hypotenuse / Opposite;

    /// <summary>
    /// Cos A
    /// </summary>
    /// <param name="Adjacent"></param>
    /// <param name="Hypotenuse"></param>
    /// <returns></returns>
    public static double CosA(double Adjacent, double Hypotenuse) => Adjacent / Hypotenuse;

    /// <summary>
    /// Secant A 1/cos(A)
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Adjacent"></param>
    /// <returns></returns>
    public static double SecA(double Hypotenuse, double Adjacent) => Hypotenuse / Adjacent;

    /// <summary>
    /// Tan A
    /// </summary>
    /// <param name="Opposite"></param>
    /// <param name="Adjacent"></param>
    /// <returns></returns>
    public static double TanA(double Opposite, double Adjacent) => Opposite / Adjacent;

    /// <summary>
    /// Cotan A 1/tan(A)
    /// </summary>
    /// <param name="Adjacent"></param>
    /// <param name="Opposite"></param>
    /// <returns></returns>
    public static double CoTA(double Adjacent, double Opposite) => Adjacent / Opposite;

    /// <summary>
    /// Calculates Adjacents from the Angle and the length of the hypotenuse.
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Angle"></param>
    /// <returns></returns>
    public static double AdjacentFromHypotenuseAngleDeg(double Hypotenuse, double Angle) => Hypotenuse * Math.Cos(Angle * Math.PI / 180);

    /// <summary>
    /// Calculates the Opposite from the Angle and the length of the hypotenuse.
    /// </summary>
    /// <param name="Hypotenuse"></param>
    /// <param name="Angle"></param>
    /// <returns></returns>
    public static double OppositeFromHypotenuseAngleDeg(double Hypotenuse, double Angle) => Hypotenuse * Math.Sin(Angle * Math.PI / 180);

    /// <summary>
    /// Calculate Hypotenuse from the Angle and the length of the Adjacent.
    /// </summary>
    /// <param name="Adjacent"></param>
    /// <param name="Angle"></param>
    /// <returns></returns>
    public static double HypotenuseFromAdjacentAngleDeg(double Adjacent, double Angle) => Adjacent / Math.Cos(Angle * (Math.PI / 180));

    /// <summary>
    /// Calculate Hypotenuse from the Angle and the length of the Opposite.
    /// </summary>
    /// <param name="Opposite"></param>
    /// <param name="Angle"></param>
    /// <returns></returns>
    public static double HypotenuseFromOppositeAngleDeg(double Opposite, double Angle) => Opposite / Math.Sin(Angle * (Math.PI / 180));

    /// <summary>
    /// Get Angle from Sin A
    /// </summary>
    /// <param name="SinAResult"></param>
    /// <returns></returns>
    public static double AngleFromSinA(double SinAResult) => Math.Asin(SinAResult) * (180 / Math.PI);

    /// <summary>
    /// Get Angle from Cos A
    /// </summary>
    /// <param name="CosAResult"></param>
    /// <returns></returns>
    public static double AngleFromCosA(double CosAResult) => Math.Acos(CosAResult) * (180 / Math.PI);

    /// <summary>
    /// Get Angle from Tan A
    /// </summary>
    /// <param name="TanAResult"></param>
    /// <returns></returns>
    public static double AngleFromTanA(double TanAResult) => Math.Atan(TanAResult) * (180 / Math.PI);
}
