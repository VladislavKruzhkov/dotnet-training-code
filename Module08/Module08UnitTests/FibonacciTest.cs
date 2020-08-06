using System;
using System.Collections.Generic;
using System.Linq;
using Fibonacci;
using NUnit.Framework;

namespace Module08UnitTests
{
    public class FibonacciTest
    {
        private static readonly List<TestCaseData> Fibonacci_TestData =
            new List<TestCaseData>(new[] 
            {
                new TestCaseData(8, new List<int> {0, 1, 1, 2, 3, 5, 8, 13}),
                new TestCaseData(0, new List<int>()), 
                new TestCaseData(1, new List<int> {0}),
                new TestCaseData(2, new List<int> {0, 1}),
                new TestCaseData(10, new List<int> {0, 1, 1, 2, 3, 5, 8, 13, 21, 34}),
            });

        [TestCaseSource(nameof(Fibonacci_TestData))]
        public void GetFibonacciNumbers_ValidParameters_CorrectResult(int number, List<int> expectedResult)
        {
            var fibonacci = new FibonacciNumbers();

            var result = fibonacci.GetFibonacciNumbers(number);
            result = result.ToList();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(int.MaxValue, typeof(OverflowException))]
        [TestCase(-1, typeof(ArgumentException))]
        public void GetFibonacciNumbers_InvalidParameters_Exception(int number, Type expectedEx)
        {
            var fibonacci = new FibonacciNumbers();

            var result = fibonacci.GetFibonacciNumbers(number);

            Assert.Throws(expectedEx, () =>result.ToList());
        }
    }
}
