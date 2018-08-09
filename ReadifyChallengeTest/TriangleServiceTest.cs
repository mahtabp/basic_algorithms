using System;
using NUnit.Framework;
using ReadifyCallenge.Services;
using ReadifyCallenge.Models;

namespace ReadifyChallengeTest
{
    [TestFixture]
    public class TriangleServiceTest
    {
        ITriangleService triangleService;

        public TriangleServiceTest()
        {
            this.triangleService = new TriangleService();
        }

        [TestCase(-1, 1, 1, ExpectedResult = TriangleType.Error)]
        [TestCase(2, -2, 2, ExpectedResult = TriangleType.Error)]
        [TestCase(3, 3, -3, ExpectedResult = TriangleType.Error)]
        [TestCase(0, 2, 2, ExpectedResult = TriangleType.Error)]
        [TestCase(2, 0, 2, ExpectedResult = TriangleType.Error)]
        [TestCase(2, 2, 0, ExpectedResult = TriangleType.Error)]
        public TriangleType GetTriangleType_InvalidValues_ReturnError(int a, int b, int c)
        {
            return triangleService.GetTriangleType(a, b, c);
        }

        [TestCase(10, 2, 20, ExpectedResult = TriangleType.Error)]
        [TestCase(1, 2, 3, ExpectedResult = TriangleType.Error)]
        public TriangleType GetTriangleType_IncorrectValues_ReturnError(int a, int b, int c)
        {
            return triangleService.GetTriangleType(a, b, c);
        }

        [TestCase(5, 5, 5, ExpectedResult = TriangleType.Equilateral)]
        [TestCase(5, 4, 3, ExpectedResult = TriangleType.Scalene)]
        [TestCase(5, 4, 5, ExpectedResult = TriangleType.Isosceles)]
        public TriangleType GetTriangleType_CorrectValues_ReturnTriangleType(int a, int b, int c)
        {
            return triangleService.GetTriangleType(a, b, c);
        }
    }
}
