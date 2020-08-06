using System;
using Calculator;
using NUnit.Framework;

namespace Module08UnitTests
{
    public class CalculatorTest
    {
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        [TestCase("5 1 + 3 /", 2)]
        [TestCase("-5 1 + 2 /", -2)]
        [TestCase("5 8 - 3 /", -1)]
        public void Calculate_ValidParameters_CorrectResult(string testEvaluation, double expected)
        {
            var calculator = new ReversePolishCalculator();

            var result = calculator.Calculate(testEvaluation);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("8 5 - 0 /", typeof(DivideByZeroException))]
        [TestCase("5 8 % 3 &", typeof(ArgumentException))]
        [TestCase("5 8 - 3 / + +", typeof(FormatException))]
        public void Calculate_InvalidParameters_Exception(string testEvaluation, Type expectedEx)
        {
            var calculator = new ReversePolishCalculator();
            Assert.Throws(expectedEx, () => calculator.Calculate(testEvaluation));
        }
    }
}
