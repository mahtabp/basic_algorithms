using System;
using BaseAlgorithms.Services;
using NUnit.Framework;

namespace BaseAlgorithmsTests
{
    [TestFixture]
    public class AlgorithmsServicesTest
    {
        IAlgorithmServices service;
        public AlgorithmsServicesTest()
        {
            service = new AlgorithmServices();
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        public long CalculateFibonacci_BaseValues_ReturnValue(long num)
        {
            return service.CalculateFibonacci(num);
        }

        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 3)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(10, ExpectedResult = 55)]
        public long CalculateFibonacci_PositiveValues_ReturnValue(long num)
        {
            return service.CalculateFibonacci(num);
        }

        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(-2, ExpectedResult = -1)]
        [TestCase(-3, ExpectedResult = 2)]
        [TestCase(-4, ExpectedResult = -3)]
        [TestCase(-5, ExpectedResult = 5)]
        [TestCase(-6, ExpectedResult = -8)]
        [TestCase(-46, ExpectedResult = -1836311903)]
        [TestCase(-47, ExpectedResult = 2971215073)]
        [TestCase(-50, ExpectedResult = -12586269025)]
        public long CalculateFibonacci_NegativeValues_ReturnNegafibonacci(int num)
        {
            long result = service.CalculateFibonacci(num);
            return result;
        }

        [Test]
        public void CalculateFibonacci_LargeValues_RetunLargeValue()
        {
            var actualResult = service.CalculateFibonacci(60);
            Assert.AreEqual(1548008755920, actualResult);
        }

        [TestCase(-93)]
        [TestCase(-94)]
        public void CalculateFibonacci_ArgumentOutOfRange_ThrowException(int num)
        {
            try
            {
                var actualResult = service.CalculateFibonacci(num);
            }
            catch (Exception ex) {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                Assert.AreEqual("Value does not fall within the expected range.", ex.Message);
            };

        }

        [Test]
        public void GetReversedSentence_EmptyString_ReturnEmpty()
        {
            var actualResult = service.GetReversedSentence("");
            Assert.AreEqual("", actualResult);
        }

        [Test]
        public void GetReversedSentence_SingleWord_ReverseSingleWord()
        {
            var actualResult = service.GetReversedSentence("Happy");
            Assert.AreEqual("yppaH", actualResult);
        }

        [Test]
        public void GetReversedSentence_Sentence_ReverseWordsInSentence()
        {
            var actualResult = service.GetReversedSentence("Happy Path");
            Assert.AreEqual("yppaH htaP", actualResult);
        }
    }
}
