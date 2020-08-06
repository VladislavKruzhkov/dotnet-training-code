using System;
using Strings;
using NUnit.Framework;

namespace UnitTestsM03
{
    public class StringTest
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

        [TestCase("omg i love shrek", "o kek", "oomg i loovee shreekk")]
        [TestCase("TestMethod2", "eeee", "TeestMeethod2")]
        [TestCase("", "", "")]
        public void DoubleLettersTest(string input1, string input2, string expectedResult)
        {
            var result = DoubleLetters.DoubleCommonLetters(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, "eee", typeof(ArgumentNullException))]
        public void DoubleLettersExceptionTest(string input1, string input2, Type exType)
        {
            Assert.Throws(exType, () => DoubleLetters.DoubleCommonLetters(input1, input2));
        }

        [TestCase("Sasha,Tanya Grisha Nastya.Ivann,    Kolyan", "5.5")]
        [TestCase("", "0")]
        [TestCase("       .,.,.,., .  ", "0")]
        public void AverageWordLengthTest(string input, double expectedResult)
        {
            var result = AverageWordLength.GetAverageWordLength(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, typeof(ArgumentNullException))]
        public void AverageWordLengthExceptionTest(string input, Type exType)
        {
            Assert.Throws(exType, () => AverageWordLength.GetAverageWordLength(input));
        }

        [TestCase("413457438957943758943795784598734985794837598735439875398547", "18678347583475983475893478957348975934875984375893475843797", "432135786541419742419689263556083961729713583111333351242344")]
        [TestCase("-10", "999", "989")]
        [TestCase("0", "-999", "-999")]
        public void SummatorTest(string input1, string input2, string expectedResult)
        {
            var result = Summator.Sum(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("", "", typeof(ArgumentException))]
        [TestCase("", "5", typeof(ArgumentException))]
        [TestCase(null, "222", typeof(ArgumentException))]
        public void SummatorExceptionTest(string input1, string input2, Type exType)
        {
            Assert.Throws(exType, () => Summator.Sum(input1, input2));
        }
    }
}
