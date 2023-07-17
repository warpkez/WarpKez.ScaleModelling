using WarpKez.ScaleModelling.FractionMathematics;
using WarpKez.ScaleModelling.MetricSystem;
using WarpKez.ScaleModelling.TrigMathematics;

namespace WarpKez.ScaleModelling.ScaleMathematics;

public static partial class ScaleMathematics
{
    private static int decimalPrecision = 2;

    /// <summary>
    /// Sets/Gets the decimal precision required for the scale measurements.  Default is 2 decimal places.
    /// </summary>
    public static int DecimalPrecision
    {
        get { return decimalPrecision; }
        set
        {
            if (value > 10) { value = 10; }
            if (value < 0) { value *= -1; }
            decimalPrecision = value;
        }
    }

    /// <summary>
    /// Converts from a given metric system to scaled millimeters
    /// </summary>
    /// <param name="metric"></param>
    /// <param name="measurement"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    private static double ScaledMillmeters(Metrics metric, double measurement, double scale)
    {
        double result = 0.0;

        switch (metric)
        {
            case Metrics.Feet:
                result = Math.Round(MetricConversion.FeetToMillimeters(measurement) / scale, DecimalPrecision);
                break;
            case Metrics.Inches:
                result = Math.Round(MetricConversion.InchesToMillimeters(measurement) / scale, DecimalPrecision);
                break;
            case Metrics.Metres:
                result = Math.Round(MetricConversion.MetersToMillimeters(measurement) / scale, DecimalPrecision);
                break;
            case Metrics.Centimetres:
                result = Math.Round(MetricConversion.CentimetersToMillimeters(measurement) / scale, DecimalPrecision);
                break;
            case Metrics.Millimetres:
                result = Math.Round((measurement) / scale, DecimalPrecision);
                break;
        }
        return result;
    }

    /// <summary>
    /// Given the metric radius, generates the plots points through a 90 degree arc.
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    public static List<CurvePlotPoints> PlotCurvePointMetric(double radius)
    {
        List<CurvePlotPoints> points = new();
        for (int i = 0; i <= 90; i++)
        {
            double X = Trigonometry.AdjacentFromHypotenuseAngleDeg(radius, i);
            double Y = Trigonometry.OppositeFromHypotenuseAngleDeg(radius, i);
            points.Add(new CurvePlotPoints() { Y = Y, X = X, Id = i });
        }

        return points;
    }

    /// <summary>
    /// Converts metric real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="metrics"></param>
    /// <param name="measurement"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static MetricModel MetricToScaleMM(Metrics metrics, double measurement, double scale)
    {
        MetricModel mm = new()
        {
            Scale = scale,
            Message = "Success"
        };

        switch (metrics)
        {
            case Metrics.Metres:
                mm.Meters = measurement;
                mm.Centimeters = measurement * 100;
                mm.Millimeters = measurement * 1000;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Centimetres:
                mm.Centimeters = measurement;
                mm.Millimeters = measurement * 10;
                mm.Meters = measurement / 100;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
            case Metrics.Millimetres:
                mm.Millimeters = measurement;
                mm.Centimeters = measurement / 10;
                mm.Meters = measurement / 1000;
                mm.ScaleMM = ScaledMillmeters(metrics, measurement, scale);
                break;
        }

        return mm;
    }

    /// <summary>
    /// Converts Imperial real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="feet"></param>
    /// <param name="inches"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static ImperialModel ImperialMeasurementToScaleMM(double feet, double inches, double scale)
    {
        ImperialModel model = new()
        {
            Feet = feet,
            Inches = inches,
            Scale = scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, MetricConversion.FeetToInches(feet) + inches, scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, MetricConversion.FeetToInches(feet) + inches, scale) / 25.4))
        };

        return model;
    }

    /// <summary>
    /// Converts Imperial real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="feet"></param>
    /// <param name="inches"></param>
    /// <param name="numerator"></param>
    /// <param name="denominator"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static ImperialModel ImperialMeasurementToScaleMM(double feet, double inches, double numerator, double denominator, double scale)
    {
        ImperialModel? model;
        if (Math.Floor(denominator) <= 0)
        {
            model = new()
            {
                Message = "Denominator cannot be Zero (0) or negative"
            };
        }
        else
        {
            model = new()
            {
                Feet = feet,
                Inches = inches,
                Numerator = Math.Floor(numerator),
                Denominator = Math.Floor(denominator),
                Scale = scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inches) + (numerator / denominator), scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inches) + (numerator / denominator), scale) / 25.4)),
                Message = "Sucess"
            };
        }

        return model!;
    }

    /// <summary>
    /// Converts Imperial real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="feet"></param>
    /// <param name="inches"></param>
    /// <param name="fraction"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static ImperialModel ImperialMeasurementToScaleMM(double feet, double inches, FractionModel fraction, double scale)
    {
        ImperialModel? model;
        if (Math.Floor((double)fraction.Denominator) <= 0)
        {
            model = new()
            {
                Message = "Denominator cannot be Zero (0) or negative"
            };
        }
        else
        {
            model = new()
            {
                Feet = feet,
                Inches = inches,
                Numerator = Math.Floor((double)fraction.Numerator),
                Denominator = Math.Floor((double)fraction.Denominator),
                Scale = scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inches) + ((double)fraction.Numerator / (double)fraction.Denominator), scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inches) + ((double)fraction.Numerator / (double)fraction.Denominator), scale) / 25.4)),
                Message = "Sucess"
            };
        }

        return model!;
    }

    /// <summary>
    /// Converts Imperial real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="imperialMeasurement"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static ImperialModel ImperialMeasurementToScaleMM(ImperialMeasurementReferenceModel imperialMeasurement, double scale)
    {
        ImperialModel? model;
        if (Math.Floor(imperialMeasurement.Denominator) <= 0)
        {
            model = new()
            {
                Message = "Denominator cannot be Zero (0) or negative"
            };
        }
        else
        {
            model = new()
            {
                Feet = imperialMeasurement.Feet,
                Inches = imperialMeasurement.Inches,
                Numerator = Math.Floor((double)imperialMeasurement.Numerator),
                Denominator = Math.Floor((double)imperialMeasurement.Denominator),
                Scale = scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(imperialMeasurement.Feet) + imperialMeasurement.Inches) + (imperialMeasurement.Numerator / imperialMeasurement.Denominator), scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(imperialMeasurement.Feet) + imperialMeasurement.Inches) + (imperialMeasurement.Numerator / imperialMeasurement.Denominator), scale) / 25.4)),
                Message = "Sucess"
            };
        }

        return model!;
    }


    /// <summary>
    /// Converts Imperial Inches real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_inches"></param>
    /// <param name="_scale"></param>
    /// <param name="_fraction"></param>
    /// <returns></returns>
    public static List<ImperialModel> InchesTable(double _inches, double _scale, InchFractions _fraction)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            Id = 0,
            Inches = _inches,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, _inches, _scale) / 25.4))
        };

        //int fraction = (int)_fraction;

        list.Add(_holder);
        for (int i = 1; i < (int)_fraction; i++)
        {
            //Mathematicals m = new();
            var simplified = Fractions.LowestCommonDenominator(i, (int)_fraction);

            _holder = new()
            {
                Id = i,
                Inches = _inches,
                Numerator = simplified.Numerator,
                Denominator = simplified.Denominator,
                Scale = _scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)(int)_fraction), _scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)(int)_fraction), _scale) / 25.4))
            };
            list.Add(_holder);
        }

        _holder = new()
        {
            Id = list.Count,
            Inches = _inches + 1,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, _inches + 1, _scale) / 25.4))
        };

        list.Add(_holder);
        return list;
    }

    /// <summary>
    /// Converts Imperial Inches real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_inches"></param>
    /// <param name="_scale"></param>
    /// <param name="fraction"></param>
    /// <returns></returns>
    public static List<ImperialModel> InchesTable(double _inches, double _scale, int fraction)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            Id = 0,
            Inches = _inches,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, _inches, _scale) / 25.4))
        };

        list.Add(_holder);
        for (int i = 1; i < fraction; i++)
        {
            //Mathematicals m = new();
            var simplified = Fractions.LowestCommonDenominator(i, fraction);

            _holder = new()
            {
                Id = i,
                Inches = _inches,
                Numerator = simplified.Numerator,
                Denominator = simplified.Denominator,
                Scale = _scale,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)fraction), _scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (double)_inches + ((double)i / (double)fraction), _scale) / 25.4))
            };
            list.Add(_holder);
        }

        _holder = new()
        {
            Id = list.Count,
            Inches = _inches + 1,
            Numerator = 0,
            Denominator = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Inches, _inches + 1, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, _inches + 1, _scale) / 25.4))
        };

        list.Add(_holder);
        return list;
    }

    /// <summary>
    /// Converts Imperial Feet real world measurements to those of the scaled world measurements
    /// </summary>
    /// <param name="_feet"></param>
    /// <param name="_scale"></param>
    /// <returns></returns>
    public static List<ImperialModel> FeetTable(double _feet, double _scale)
    {
        List<ImperialModel> list = new();
        ImperialModel _holder = new()
        {
            Id = 0,
            Feet = _feet,
            Inches = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Feet, _feet, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, _feet, _scale) / 25.4))
        };

        list.Add(_holder);

        for (int i = 1; i < 12; i++)
        {
            _holder = new()
            {
                Id = i,
                Feet = _feet,
                Scale = _scale,
                Inches = i,
                ScaleMM = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(_feet) + i), _scale),
                ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(_feet) + i), _scale) / 25.4))
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            Id = list.Count,
            Feet = _feet + 1,
            Inches = 0,
            Scale = _scale,
            ScaleMM = ScaledMillmeters(Metrics.Feet, _feet + 1, _scale),
            ScaledInches = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, _feet + 1, _scale) / 25.4))
        };

        list.Add(_holder);

        return list;
    }

    /// <summary>
    /// Generates a table across multiple scales for a given footage
    /// </summary>
    /// <param name="feet"></param>
    /// <returns></returns>
    public static List<MultiScaleMetricModel> MultiScaleTable(int feet)
    {
        List<MultiScaleMetricModel> list = new();
        MultiScaleMetricModel _holder = new()
        {
            Feet = feet,
            Inches = 0,
            Id = list.Count,
            Scale160 = ScaledMillmeters(Metrics.Feet, feet, 160),
            Scale120 = ScaledMillmeters(Metrics.Feet, feet, 120),
            Scale87 = ScaledMillmeters(Metrics.Feet, feet, 87),
            Scale76 = ScaledMillmeters(Metrics.Feet, feet, 76),
            Scale64 = ScaledMillmeters(Metrics.Feet, feet, 64),
            Scale48 = ScaledMillmeters(Metrics.Feet, feet, 48)
        };

        list.Add(_holder);

        for (int inch = 1; inch < 12; inch++)
        {
            _holder = new()
            {
                Id = inch,
                Feet = feet,
                Inches = inch,

                Scale160 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 160),
                Scale120 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 120),
                Scale87 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 87),
                Scale76 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 76),
                Scale64 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 64),
                Scale48 = ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 48)
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            Feet = feet + 1,
            Inches = 0,
            Id = list.Count,
            Scale160 = ScaledMillmeters(Metrics.Feet, feet + 1, 160),
            Scale120 = ScaledMillmeters(Metrics.Feet, feet + 1, 120),
            Scale87 = ScaledMillmeters(Metrics.Feet, feet + 1, 87),
            Scale76 = ScaledMillmeters(Metrics.Feet, feet + 1, 76),
            Scale64 = ScaledMillmeters(Metrics.Feet, feet + 1, 64),
            Scale48 = ScaledMillmeters(Metrics.Feet, feet + 1, 48)
        };

        list.Add(_holder);

        return list;
    }

    /// <summary>
    /// Generates a ballpark table across multiple scales for a given footage
    /// </summary>
    /// <param name="feet"></param>
    /// <returns></returns>
    public static List<MultiScaleImperialModel> MultiScaleImperialTable(int feet)
    {
        List<MultiScaleImperialModel> list = new();
        MultiScaleImperialModel _holder = new()
        {
            Feet = feet,
            Inches = 0,
            Id = list.Count,
            Scale160 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 160) / 25.4)),
            Scale120 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 120) / 25.4)),
            Scale87 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 87) / 25.4)),
            Scale76 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 76) / 25.4)),
            Scale64 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 64) / 25.4)),
            Scale48 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet, 48) / 25.4))
        };

        list.Add(_holder);

        for (int inch = 1; inch < 12; inch++)
        {
            _holder = new()
            {
                Id = inch,
                Feet = feet,
                Inches = inch,

                Scale160 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 160) / 25.4)),
                Scale120 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 120) / 25.4)),
                Scale87 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 87) / 25.4)),
                Scale76 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 76) / 25.4)),
                Scale64 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 64) / 25.4)),
                Scale48 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Inches, (MetricConversion.FeetToInches(feet) + inch), 48) / 25.4))
            };

            list.Add(_holder);
        }

        _holder = new()
        {
            Feet = feet + 1,
            Inches = 0,
            Id = list.Count,
            Scale160 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 160) / 25.4)),
            Scale120 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 120) / 25.4)),
            Scale87 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 87) / 25.4)),
            Scale76 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 76) / 25.4)),
            Scale64 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 64) / 25.4)),
            Scale48 = MetricConversion.ClosestInchAsFraction((decimal)(ScaledMillmeters(Metrics.Feet, feet + 1, 48) / 25.4))
        };

        list.Add(_holder);

        return list;
    }
}