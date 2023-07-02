// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using WarpKez.ScaleModelling.FractionMathematics;
using WarpKez.ScaleModelling.MetricSystem;

//var fraction = Fractions.FractionMultiply(1, 2, 1, 3);

var fraction = Fractions.LowestCommonDenominator(65, 32);

Console.WriteLine($"{fraction.Unit} & {fraction.Numerator}/{fraction.Denominator}");
Console.WriteLine($"{fraction.Message}");

//decimal x = 1.24M;
//var inchFraction = MetricConversion.ClosestInchAsFraction(x);

//Console.WriteLine($"{inchFraction.LowerCommonFraction!.Unit} & {inchFraction.LowerCommonFraction.Numerator}/{inchFraction.LowerCommonFraction.Denominator}");
//Console.WriteLine($"{inchFraction.InchAsFraction!.Unit} & {inchFraction.InchAsFraction.Numerator}/{inchFraction.InchAsFraction.Denominator}");
//Console.WriteLine($"{inchFraction.UpperCommonFraction!.Unit} & {inchFraction.UpperCommonFraction.Numerator}/{inchFraction.UpperCommonFraction.Denominator}");
