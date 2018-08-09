using System;
using BaseAlgorithms.Models;

namespace BaseAlgorithms.Services
{
    public interface ITriangleService
    {
        TriangleType GetTriangleType(int a, int b, int c);
    }

    public class TriangleService: ITriangleService
    {
        public TriangleType GetTriangleType(int a, int b, int c)
        {
            var triangle = new Triangle(a, b, c);
            return triangle.TriangleType;
        }
    }
}
