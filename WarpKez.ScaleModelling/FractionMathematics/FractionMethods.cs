namespace WarpKez.ScaleModelling.FractionMathematics;

public static partial class Fractions
{
    /// <summary>
    /// Worker method for the adding of fractions
    /// </summary>
    /// <param name="firstNumerator"></param>
    /// <param name="firstDenominator"></param>
    /// <param name="secondNumerator"></param>
    /// <param name="secondDenominator"></param>
    /// <returns></returns>
    private static FractionModel FractionAddMethod(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator)
    {
        FractionModel fraction = new();

        // Check if the fractions have the same denominator
        if (firstDenominator != secondDenominator)
        {
            // Cross multiple 
            fraction.Numerator = (firstNumerator * secondDenominator) + (secondNumerator * firstDenominator);
            fraction.Denominator = firstDenominator * secondDenominator;

        }
        else
        {
            // Just add the numerators
            fraction.Numerator = (firstNumerator + secondNumerator);
            fraction.Denominator = firstDenominator;
        }

        return fraction;
    }

    /// <summary>
    /// Worker method for subtracting fractions
    /// </summary>
    /// <param name="firstNumerator"></param>
    /// <param name="firstDenominator"></param>
    /// <param name="secondNumerator"></param>
    /// <param name="secondDenominator"></param>
    /// <returns></returns>
    private static FractionModel FractionSubtractMethod(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator)
    {
        FractionModel fraction = new();

        // Check if the fractions have the same denominator
        if (firstDenominator != secondDenominator)
        {
            // Cross multiple 
            fraction.Numerator = (firstNumerator * secondDenominator) - (secondNumerator * firstDenominator);
            fraction.Denominator = firstDenominator * secondDenominator;

        }
        else
        {
            // Just subtract the numerators
            fraction.Numerator = (firstNumerator - secondNumerator);
            fraction.Denominator = firstDenominator;
        }

        return fraction;
    }

    /// <summary>
    /// Worker method for multiplying fractions
    /// </summary>
    /// <param name="firstNumerator"></param>
    /// <param name="firstDenominator"></param>
    /// <param name="secondNumerator"></param>
    /// <param name="secondDemoninator"></param>
    /// <returns></returns>
    private static FractionModel FractionMultiplyMethod(int firstNumerator, int firstDenominator, int secondNumerator, int secondDemoninator)
    {
        FractionModel fraction = new()
        {

            Numerator = firstNumerator * secondNumerator,
            Denominator = firstDenominator * secondDemoninator
        };
        return fraction;
    }

    /// <summary>
    /// Worker method for dividing fractions
    /// </summary>
    /// <param name="firstNumerator"></param>
    /// <param name="firstDenominator"></param>
    /// <param name="secondNumerator"></param>
    /// <param name="secondDemoninator"></param>
    /// <returns></returns>
    private static FractionModel FractionDivideMethod(int firstNumerator, int firstDenominator, int secondNumerator, int secondDemoninator)
    {
        FractionModel fraction = new()
        {
            Numerator = firstNumerator * secondDemoninator,
            Denominator = firstDenominator * secondNumerator
        };

        return fraction;
    }

    /// <summary>
    /// Find the lowest common denomoniator
    /// </summary>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    private static FractionImproperModel LowestCommonDenominatorMethod(int Numerator, int Denominator)
    {
        FractionImproperModel fraction = new();
        try
        {
            int HighComDivisor = 0;
            int[] values = new int[2];

            // If numerator less than 0 drop out
            if ((Numerator > 0) || (Denominator > 0))
            {
                for (int _HighComDividor = 1; _HighComDividor <= Denominator; _HighComDividor++)
                {
                    if ((Numerator % _HighComDividor == 0) && (Denominator % _HighComDividor == 0))
                    {
                        HighComDivisor = _HighComDividor;
                    }

                    values[0] = Numerator / HighComDivisor;
                    values[1] = Denominator / HighComDivisor;
                }

                ///////////////////////////////////
                // Check if a proper or improper fraction
                if (values[0] > values[1])
                {
                    int Unit = Math.Abs(values[0] / values[1]);
                    int newNumerator = values[0] - (Unit * values[1]);
                    fraction.Unit = Unit;
                    fraction.Numerator = newNumerator;
                    fraction.Denominator = values[1];
                }
                else
                {
                    fraction.Unit = 0;
                    fraction.Numerator = values[0];
                    fraction.Denominator = values[1];
                }

                fraction.Message = "Success";
                /////////////////////////////
            }
            else
            {
                values[0] = Numerator;
                values[1] = Denominator;
                fraction.Numerator = Numerator;
                fraction.Denominator = Denominator;
                fraction.Message = "Attemping to use Zeros";
            }

        }
        /// Divide by zero, or integer overflow.  
        /// By sanitising for negative numbers it should be less likely to happen
        catch (Exception ex)
        {
            fraction.Message = ex.Message;
        }

        return fraction;
    }
}
