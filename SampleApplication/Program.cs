// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using WarpKez.ScaleModelling.FractionMathematics;

//var fraction = Fractions.FractionMultiply(1, 2, 1, 3);

var fraction = Fractions.LowestCommonDenominator(65, 32);

Console.WriteLine($"{fraction.Unit} & {fraction.Numerator}/{fraction.Denominator}");
Console.WriteLine($"{fraction.Message}" );
