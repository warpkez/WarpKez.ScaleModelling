namespace WarpKez.ScaleModelling.FractionMathematics;

public static partial class Fractions
{
    /// <summary>
    /// Performs the addition of two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionAdd(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator) =>
        FractionAddMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);

    /// <summary>
    /// Performs the addition of two fractions
    /// </summary>
    /// <param name="FirstFraction"></param>
    /// <param name="SecondFraction"></param>
    /// <returns></returns>
    public static FractionModel FractionAdd(FractionModel FirstFraction, FractionModel SecondFraction) =>
        FractionAddMethod(FirstFraction.Numerator,FirstFraction.Denominator, SecondFraction.Numerator, SecondFraction.Denominator);

    /// <summary>
    /// Ensures that two fractions are positive before performing the addition operation
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionAddSanitised(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        if (FirstNumerator < 0) FirstNumerator *= -1;
        if (FirstDenominator < 0) FirstDenominator *= -1;
        if (SecondNumerator < 0) SecondNumerator *= -1;
        if (SecondDenominator < 0) SecondDenominator *= -1;

        return FractionAddMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);
    }

    /// <summary>
    /// Performs the subtraction of two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionSubtract(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator) =>
        FractionSubtractMethod(FirstNumerator,FirstDenominator, SecondNumerator,SecondDenominator);

    /// <summary>
    /// Performs the subtraction of two fractions
    /// </summary>
    /// <param name="FirstFraction"></param>
    /// <param name="SecondFraction"></param>
    /// <returns></returns>
    public static FractionModel FractionSubtract(FractionModel FirstFraction, FractionModel SecondFraction) =>
        FractionSubtractMethod(FirstFraction.Numerator,FirstFraction.Denominator,SecondFraction.Numerator,SecondFraction.Denominator);

    /// <summary>
    /// Ensures that two fractions are positive before performing the subtraction operation
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionSubstractSanitise(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        if (FirstNumerator < 0) FirstNumerator *= -1;
        if (FirstDenominator < 0) FirstDenominator *= -1;
        if (SecondNumerator < 0) SecondNumerator *= -1;
        if (SecondDenominator < 0) SecondDenominator *= -1;

        return FractionSubtractMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);
    }

    /// <summary>
    /// Performs the multiplication of two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionMultiply (int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator) =>
        FractionMultiplyMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);

    /// <summary>
    /// Performs the multiplication of two fractions
    /// </summary>
    /// <param name="FirstFraction"></param>
    /// <param name="SecondFraction"></param>
    /// <returns></returns>
    public static FractionModel FractionMultiply (FractionModel FirstFraction, FractionModel SecondFraction) =>
        FractionMultiplyMethod(FirstFraction.Numerator,FirstFraction.Denominator, SecondFraction.Numerator, SecondFraction.Denominator);

    /// <summary>
    /// Ensures that two fractions are positive before performing the multiplication operation
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionMultiplySantise(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        if (FirstNumerator < 0) FirstNumerator *= -1;
        if (FirstDenominator < 0) FirstDenominator *= -1;
        if (SecondNumerator < 0) SecondNumerator *= -1;
        if (SecondDenominator < 0) SecondDenominator *= -1;

        return FractionMultiplyMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);
    }

    /// <summary>
    /// Performs the division of two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionDivide (int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator) =>
        FractionDivideMethod(FirstNumerator,FirstDenominator, SecondNumerator,SecondDenominator);

    /// <summary>
    /// Performs the division of two fractions
    /// </summary>
    /// <param name="FirstFraction"></param>
    /// <param name="SecondFraction"></param>
    /// <returns></returns>
    public static FractionModel FractionDivide (FractionModel FirstFraction, FractionModel SecondFraction) =>
        FractionDivideMethod(FirstFraction.Numerator,FirstFraction.Denominator,SecondFraction.Numerator, SecondFraction.Denominator);

    /// <summary>
    /// Ensures that two fractions are positive before performing the division operation
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel FractionDivideSanitise(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        if (FirstNumerator < 0) FirstNumerator *= -1;
        if (FirstDenominator < 0) FirstDenominator *= -1;
        if (SecondNumerator < 0) SecondNumerator *= -1;
        if (SecondDenominator < 0) SecondDenominator *= -1;

        return FractionDivideMethod(FirstNumerator, FirstDenominator, SecondNumerator, SecondDenominator);
    }

    public static FractionImproperModel LowestCommonDenominator(int Numerator, int Denominator) => LowestCommonDenominatorSanitisor (Numerator, Denominator);
    public static FractionImproperModel LowestCommonDenominator(FractionModel fractionModel) => LowestCommonDenominatorSanitisor (fractionModel.Numerator, fractionModel.Denominator);

    ///// <summary>
    ///// Find the lowest common denominator for a fraction.  Pre-sanitises the fraction
    ///// </summary>
    ///// <param name="Numerator"></param>
    ///// <param name="Denominator"></param>
    ///// <returns></returns>
    //public static FractionImproperModel LowestCommonDenominator(int Numerator, int Denominator)
    //{    
    //    /// If the Numerator or the Denominator
    //    /// are sanitised this needs to be tracked
    //    bool n = false, d = false;
    //    FractionImproperModel? lcd;

    //    /// Sanitise the Numerator and Denominator before passing them to the method
    //    if (Numerator < 0)
    //    {
    //        n = true;
    //        Numerator *= -1;
    //    }
    //    if (Denominator < 0)
    //    {
    //        d = true;
    //        Denominator *= -1;
    //    }

    //    lcd = LowestCommonDenominatorMethod(Numerator, Denominator);

    //    /// Desanitise the fractions before returning it.
    //    /// For an improper fraction, this is the unit that has the sign, otherwise
    //    /// the numerator, but the denominator can also have the negative sign applied.
    //    if (n || d)
    //    {
    //        if (lcd.Unit > 0)
    //        {
    //            lcd.Unit *= -1;
    //        }
    //        else
    //        {
    //            lcd.Numerator *= -1;
    //        }
    //    }

    //    return lcd;
    //}

    /// <summary>
    /// Returns a Numerator/Denominator of a simplified improper fraction using unit, numerator and denominator.
    /// </summary>
    /// <param name="Unit"></param>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public static FractionModel Fraction(int Unit, int Numerator, int Denominator) => new()
    {
        Numerator = (Unit * Denominator) + Numerator,
        Denominator = Denominator
    };

    public static FractionModel Fraction(FractionImproperModel fractionImproper) => new()
    {
        Numerator = (fractionImproper.Unit * fractionImproper.Denominator) + fractionImproper.Numerator,
        Denominator = fractionImproper.Denominator
    };
}
