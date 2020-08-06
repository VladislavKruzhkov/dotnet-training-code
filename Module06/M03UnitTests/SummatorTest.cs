using System;
using NUnit.Framework;
using Strings;

namespace Module06.M03UnitTests
{
    public class SummatorTest
    {
        [TestCase("413457438957943758943795784598734985794837598735439875398547", "18678347583475983475893478957348975934875984375893475843797", "432135786541419742419689263556083961729713583111333351242344")]
        [TestCase("-10", "999", "989")]
        [TestCase("0", "-999", "-999")]
        [TestCase("0", "999", "999")]
        [TestCase("0", "0", "0")]
        [TestCase("777", "999", "1776")]
        [TestCase("-777", "-999", "-1776")]
        public void SumTest(string input1, string input2, string expectedResult)
        {
            var result = Summator.Sum(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("", "", typeof(ArgumentException))]
        [TestCase("", "5", typeof(ArgumentException))]
        [TestCase(null, "222", typeof(ArgumentException))]
        [TestCase("sdggs", "222", typeof(FormatException))]
        public void SumExceptionTest(string input1, string input2, Type exType)
        {
            Assert.Throws(exType, () => Summator.Sum(input1, input2));
        }
    }
}
