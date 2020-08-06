using System;
using NUnit.Framework;
using Strings;

namespace Module06.M03UnitTests
{
    public class SentenceReverserTest
    {
        [TestCase("The greatest victory is that which requires no battle", "battle no requires which that is victory greatest The")]
        [TestCase("WORD", "WORD")]
        [TestCase("", "")]
        [TestCase("  WORD", "WORD")]
        [TestCase("  WORD      ", "WORD")]
        [TestCase("  143145     123 ", "123 143145")]
        public void ReverseWordsTest(string input, string expectedResult)
        {
            var result = SentenceReverser.ReverseWords(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        public void ReverseWordsExceptionTest(string input, Type exType)
        {
            Assert.Throws(exType, () => SentenceReverser.ReverseWords(input));
        }
    }
}
