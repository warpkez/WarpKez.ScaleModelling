using WarpKez.ScaleModelling.FractionMathematics;

namespace WarpKez.ScaleModelling.MetricSystem;

public static partial class MetricConversion
{
    private static ImperialClosestFractionModel ClosestInchAsFractionWorker(decimal DecimalInches)
    {
        /// Using maxDecimalPlaces to prevent a integer overflow
        /// when some doubles/decimals exceed the 16 digits
        DecimalInches = Math.Round(DecimalInches, maxDecimalPlaces);

        ImperialClosestFractionModel model = new() { InchesAsDecimal = (double)DecimalInches };
        int above = 0, below = 0;

        /// Find how many decimal places to the right
        /// This is now redundant as we are only look at a specific number
        /// of decimal places and not all of them anymore.
        //string xString = DecimalInches.ToString();
        //int decimalPlaces = xString.Length - xString.IndexOf('.') - 1;

        /// If there is anything to the left of the decimal grab that
        /// then assign the balance to variable.
        int localUnit = (int)Math.Floor(DecimalInches);
        decimal localInches = DecimalInches - localUnit;
        //decimal _inches = (double)_MyInches;     //DecimalInches - (double)localUnit;

        decimal localNumerator = Math.Floor(localInches * baseDenominator);
        decimal localDenominator = baseDenominator;

        var simplified = Fractions.LowestCommonDenominator(Fractions.Fraction(localUnit, (int)localNumerator, (int)localDenominator));
        model.InchAsFraction = simplified;

        /// This is not the best way of doing this, but it does work.
        /// There is a way of multiplying the decimal result by the increment
        /// but this made no sense to me as it dealt with larger than a fraction 
        /// which is more common in scale modelling.
        for (int i = 1; i < (int)InchPrecision; i++)
        {
            double _math = (double)i / (double)inchPrecision;
            if ((_math) <= (double)localInches)
            {
                below = i;
            }
            else { break; }
        }

        var SimpliefiedBelow = Fractions.LowestCommonDenominator(Fractions.Fraction(localUnit, below, (int)inchPrecision));
        model.LowerCommonFraction = SimpliefiedBelow;
        model.LowerInchDecimal = (double)SimpliefiedBelow.Unit + ((double)SimpliefiedBelow.Numerator / (double)SimpliefiedBelow.Denominator);

        for (int i = (int)InchPrecision; i > 1; i--)
        {
            double _math = (double)i / (double)inchPrecision;
            if (_math >= (double)localInches)
            {
                above = i;
            }
            else { break; }
        }
        var SimpliefiedAbove = Fractions.LowestCommonDenominator(Fractions.Fraction(localUnit, above, (int)InchPrecision));
        model.UpperCommonFraction = SimpliefiedAbove;
        model.UpperInchDecimal = (double)SimpliefiedAbove.Unit + ((double)SimpliefiedAbove.Numerator / (double)SimpliefiedAbove.Denominator);
        return model;
    }
}
