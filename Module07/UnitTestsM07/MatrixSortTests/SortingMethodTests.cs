using System;
using MatrixSort;
using NUnit.Framework;

namespace UnitTestsM07.MatrixSortTests
{
    public class SortingMethodTests
    {
        [TestCase(new[] { 0, 1, 3 }, new[] { 2, 3, 4 }, -1)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }, 0)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 0, 1, 3 }, 1)]
        public void CompareSumOfElementsInRowsTest(int[] input1, int[] input2, int expectedResult)
        {
            var result = SortingMethod.CompareSumOfElementsInRows(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new[] { 0, 1, 3 }, new[] { 2, 3, 4 }, -1)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }, 0)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 0, 1, 3 }, 1)]
        public void CompareMinElementsInRowsTest(int[] input1, int[] input2, int expectedResult)
        {
            var result = SortingMethod.CompareMinElementsInRows(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new[] { 0, 1, 3 }, new[] { 2, 3, 4 }, -1)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }, 0)]
        [TestCase(new[] { 2, 3, 4 }, new[] { 0, 1, 3 }, 1)]
        public void CompareMaxElementsInRowsTest(int[] input1, int[] input2, int expectedResult)
        {
            var result = SortingMethod.CompareMaxElementsInRows(input1, input2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null, new[] { 2, 3, 4 }, typeof(ArgumentNullException))]
        [TestCase(new[] { 2, 3, 4 }, null, typeof(ArgumentNullException))]
        [TestCase(null, null, typeof(ArgumentNullException))]
        public void SortingMethodExceptionTests(int[] input1, int[] input2, Type exType)
        {
            Assert.Throws(exType, () => SortingMethod.CompareMaxElementsInRows(input1, input2));

            Assert.Throws(exType, () => SortingMethod.CompareMinElementsInRows(input1, input2));

            Assert.Throws(exType, () => SortingMethod.CompareSumOfElementsInRows(input1, input2));
        }

    }
}