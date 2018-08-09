using System;
namespace BaseAlgorithms.Models
{
    public class Triangle
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public TriangleType TriangleType { get; private set; }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.TriangleType = GetTriangleType();
        }

        private TriangleType GetTriangleType()
        {
            if (!AreDimensionsValidForTriangle())
                return TriangleType.Error;
            
            if (a == b && b == c)
                return TriangleType.Equilateral;
            if (a == b || a == c || b == c)
                return TriangleType.Isosceles;
            if (a != b && b != c && a != c)
                return TriangleType.Scalene;
            
            return TriangleType.Error;
        }


        // is valid if none of the values are negative or 0 && 
        // a + b > c
        // a + c > b
        // b + c > a
        private bool AreDimensionsValidForTriangle()
        {
            if (a <= 0 || b <= 0 || c <= 0)
                return false;

            if (a + b > c && a + c > b && b + c > a)
                return true;

            return false;
        }

    }
}
