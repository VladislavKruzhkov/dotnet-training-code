using System;
using NUnit.Framework;
using Strings;

namespace Module06.M03UnitTests
{
    public class AverageWordLengthTest
    {
        [TestCase("Sasha,Tanya Grisha Nastya.Ivann,    Kolyan", "5.5")]
        [TestCase("", "0")]
        [TestCase("       .,.,.,., .  ", "0")]
        [TestCase("fdhjksfhruyskldfjmt", "19")]
        public void GetAverageWordLengthTest(string input, double expectedResult)
        {
            var result = AverageWordLength.GetAverageWordLength(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        public void GetAverageWordLengthExceptionTest(string input, Type exType)
        {
            Assert.Throws(exType, () => AverageWordLength.GetAverageWordLength(input));
        }
    }
}