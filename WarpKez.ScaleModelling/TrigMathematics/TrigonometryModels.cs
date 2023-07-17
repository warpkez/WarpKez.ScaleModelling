namespace WarpKez.ScaleModelling.TrigMathematics;

/// <summary>
/// Basics of Pythagorean theorem a^2 + b^2 = c^2
/// </summary>
enum RightAngleTriangleTestValues
{
    Adjacent = 3,
    Opposite = 4,
    Hypotenuse = 5
}

/// <summary>
/// Types of triangles
/// </summary>
enum TriangleTyles
{
    RightAngle,
    Equilateral,
    Isosceles,
    Scalene,
    Acute,
    Obtuse
}

/// <summary>
/// Model for a Right Angle Triangle
/// </summary>
public class RightAngleTriangleModel
{
    /// <summary>
    /// Hypotenuse and adjacent    
    /// eg /_
    /// </summary>
    public double Angle_A { get; set; }

    /// <summary>
    /// Hypotenuse and opposite    
    /// eg /|
    /// </summary>
    public double Angle_B { get; set; }

    /// <summary>
    /// Adjacent and opposite    
    /// eg _|
    /// </summary>
    public double Angle_C { get; set; } = 90;

    public double Adjacent { get; set; }
    public double Opposite { get; set; }
    public double Hypotenuse { get; set; }
}
