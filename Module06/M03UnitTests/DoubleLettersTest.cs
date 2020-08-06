using System;
using NUnit.Framework;
using Strings;

namespace Module06.M03UnitTests
{
    public class DoubleLettersTest
    {
        [TestCase("omg i love shrek", "o kek", "oomg i loovee shreekk")]
        [TestCase("TestMethod2", "eeee", "TeestMeethod2")]
        [TestCase("", "", "")]
        [TestCase("The string shouldn't be changed", "", "The string shouldn't be changed")]
        [TestCase("", "1st string is empty", "")]
        public void DoubleCommonLettersTest(string input1, string input2, string expectedResult)
        {
            var result = DoubleLetters.DoubleCommonLetters(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, "eee", typeof(ArgumentNullException))]
        [TestCase("eee", null, typeof(ArgumentNullException))]
        public void DoubleCommonLettersExceptionTest(string input1, string input2, Type exType)
        {
            Assert.Throws(exType, () => DoubleLetters.DoubleCommonLetters(input1, input2));
        }
    }
}
