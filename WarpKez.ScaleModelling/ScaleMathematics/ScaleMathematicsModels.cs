using Newtonsoft.Json;
using WarpKez.ScaleModelling.MetricSystem;

namespace WarpKez.ScaleModelling.ScaleMathematics;

/// <summary>
/// Imperial metric system model
/// </summary>
public class ImperialModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public double Numerator { get; set; } = 0;
    public double Denominator { get; set; } = 0;
    public double Scale { get; set; } = 0.0;
    public double ScaleMM { get; set; } = 0.0;
    public ImperialClosestFractionModel? ScaledInches { get; set; }
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Imperial Measurements Reference Model including support for fractions.
/// A model used for reference measurements of real world objects.
/// </summary>
/// <value>Feet, Inches, Numerator, Denominator Example: 1' 6 1/4"</value>
public class ImperialMeasurementReferenceModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public double Numerator { get; set; } = 0.0;
    public double Denominator { get; set; } = 0.0;
}

/// <summary>
/// Metric Measurements Model.  Can be output as a JSON record.
/// </summary>
public class MetricModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public double Meters { get; set; } = 0.0;
    public double Centimeters { get; set; } = 0.0;
    public double Millimeters { get; set; } = 0.0;
    public double Scale { get; set; } = 0.0;
    public double ScaleMM { get; set; } = 0.0;
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Multiple scale table model.  Can be output as a JSON record.
/// </summary>
public class MultiScaleMetricModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public double Scale87 { get; set; } = 0.0;      // 1:87
    public double Scale76 { get; set; } = 0.0;      // 1:76
    public double Scale64 { get; set; } = 0.0;      // 1:64
    public double Scale48 { get; set; } = 0.0;      // 1:48
    public double Scale120 { get; set; } = 0.0;     // 1:120
    public double Scale160 { get; set; } = 0.0;     // 1:160
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Table model for Imperial measurements. Can be output as a JSON record.
/// </summary>
public class MultiScaleImperialModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public double Feet { get; set; } = 0.0;
    public double Inches { get; set; } = 0.0;
    public ImperialClosestFractionModel? Scale87 { get; set; }       // 1:87
    public ImperialClosestFractionModel? Scale76 { get; set; }       // 1:76
    public ImperialClosestFractionModel? Scale64 { get; set; }       // 1:64
    public ImperialClosestFractionModel? Scale48 { get; set; }       // 1:48
    public ImperialClosestFractionModel? Scale120 { get; set; }      // 1:120
    public ImperialClosestFractionModel? Scale160 { get; set; }      // 1:160
    public string Message { get; set; } = string.Empty;
}

/// <summary>
/// Model for calculating the gradient of a slope.
/// </summary>
public class GradientModel
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;
    public decimal Rise { get; set; }
    public decimal Run { get; set; }
    public decimal Gradient => Rise / Run;
    public decimal GradientPercent => Gradient * 100;
}

public class CurvePlotPoints
{
    [JsonProperty("id")]
    public int Id { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}