using System;
using System.Collections.Generic;
using BinarySearch;
using NUnit.Framework;

namespace Module08UnitTests
{
    public class BinarySearchTest
    {
        private static readonly List<TestCaseData> Search_TestData =
            new List<TestCaseData>(new[]
            {
                new TestCaseData(3, new[] {1, 2, 3}, 2),
                new TestCaseData(5, new[] {1, 2, 3}, -1),
                new TestCaseData(0, new[] {0, 0, 0}, 1),
                new TestCaseData(0, new[] {0, 1, 2}, 0)
            });

        [TestCaseSource(nameof(Search_TestData))]
        public void Search_ValidParameters_CorrectResult(int item, int[] testArray, int expectedResult)
        {
            var result = BinarySearcher<int>.Search(item, testArray, Comparer<int>.Default);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static readonly List<TestCaseData> Search_ExceptionTestData =
            new List<TestCaseData>(new[]
            {
                new TestCaseData("3", null, typeof(ArgumentException)),
                new TestCaseData("5", new string[] {}, typeof(ArgumentException)),
                new TestCaseData(null, new[] {"0", "1", "2"}, typeof(ArgumentException))
            });

        [TestCaseSource(nameof(Search_ExceptionTestData))]
        public void Search_InvalidParameters_Exception(string item, string[] testArray, Type expectedEx)
        {
            Assert.Throws(expectedEx, () => BinarySearcher<string>.Search(item, testArray, Comparer<string>.Default));
        }
    }
}