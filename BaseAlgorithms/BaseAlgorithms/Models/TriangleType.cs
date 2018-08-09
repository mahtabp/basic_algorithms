using System;
namespace BaseAlgorithms.Models
{
    // Ref: https://www.cut-the-knot.org/triangle/Triangles.shtml
    /// <summary>
    /// As regard their sides, triangles may be
    /// Equilateral(all three sides are equal)
    /// Scalene(all sides are different)
    /// Isosceles(two sides are equal)
    /// </summary>
    public enum TriangleType
    {
        Equilateral = 1, 
        Scalene = 2, 
        Isosceles = 3,
        Error = 4
    }

}
