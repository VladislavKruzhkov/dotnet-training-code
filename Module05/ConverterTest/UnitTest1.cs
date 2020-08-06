using System;
using Module05;
using NLog;
using NUnit.Framework;

namespace ConverterTest
{
    public class StringTest
    {
        [TestCase("12345", 12345)]
        [TestCase("345345346", 345345346)]
        [TestCase("0", 0)]
        [TestCase("-435345", -435345)]
        [TestCase("2147483647", 2147483647)]
        [TestCase("-2147483647", -2147483647)]
        public void ConvertToIntNumberTest(string input, int expectedResult)
        {
            var stringConverter = new Converter();
            var result = stringConverter.ConvertToIntNumber(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        [TestCase("-asfasf", typeof(ArgumentException))]
        [TestCase("asfasf", typeof(ArgumentException))]
        [TestCase("345gssd43", typeof(ArgumentException))]
        [TestCase("", typeof(ArgumentException))]
        [TestCase("2147483648", typeof(OverflowException))]
        public void ConvertToIntNumberExceptionTest(string input, Type exType)
        {
            var stringConverter = new Converter();
            Assert.Throws(exType, () => stringConverter.ConvertToIntNumber(input));
        }
    }
}