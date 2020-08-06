using System;
using System.Collections.Generic;
using MatrixSort;
using NUnit.Framework;

namespace UnitTestsM07.MatrixSortTests
{
    public class MatrixSorterTests
    {
        private static readonly List<TestCaseData> SortBySumTestData =
            new List<TestCaseData>(new[]
                {
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 2}}, new[,] {{1, 2}, {3, 4}, {5, 2}}, MatrixSorter.SortingDirection.Ascending),
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 2}}, new[,] {{3, 4}, {5, 2}, {1, 2}}, MatrixSorter.SortingDirection.Descending),
                    new TestCaseData(new[,] {{3, 4}, {4, 3}, {2, 5}}, new[,] {{3, 4}, {4, 3}, {2, 5}}, MatrixSorter.SortingDirection.Descending),
                }
            );

        [TestCaseSource(nameof(SortBySumTestData))]
        public void SortBySumOfElementsTest(int[,] input, int[,] expectedResult, MatrixSorter.SortingDirection direction)
        {
            var result = MatrixSorter.BubbleSort(input, SortingMethod.CompareSumOfElementsInRows, direction);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static readonly List<TestCaseData> SortByMaxElementTestData =
            new List<TestCaseData>(new[]
                {
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 2}}, new[,] {{1, 2}, {3, 4}, {5, 2}}, MatrixSorter.SortingDirection.Ascending),
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 2}}, new[,] {{5, 2}, {3, 4}, {1, 2}}, MatrixSorter.SortingDirection.Descending),
                    new TestCaseData(new[,] {{3, 4}, {4, 3}, {4, 1}}, new[,] {{3, 4}, {4, 3}, {4, 1}}, MatrixSorter.SortingDirection.Descending),
                }
            );

        [TestCaseSource(nameof(SortByMaxElementTestData))]
        public void SortByMaxElementTest(int[,] input, int[,] expectedResult, MatrixSorter.SortingDirection direction)
        {
            var result = MatrixSorter.BubbleSort(input, SortingMethod.CompareMaxElementsInRows, direction);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static readonly List<TestCaseData> SortByMinElementTestData =
            new List<TestCaseData>(new[]
                {
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 2}}, new[,] {{1, 2}, {5, 2}, {3, 4}}, MatrixSorter.SortingDirection.Ascending),
                    new TestCaseData(new[,] {{3, 4}, {1, 2}, {5, 6}}, new[,] {{5, 6}, {3, 4}, {1, 2}}, MatrixSorter.SortingDirection.Descending),
                    new TestCaseData(new[,] {{1, 4}, {4, 1}, {3, 1}}, new[,] {{1, 4}, {4, 1}, {3, 1}}, MatrixSorter.SortingDirection.Descending),
                }
            );

        [TestCaseSource(nameof(SortByMinElementTestData))]
        public void SortByMinElementTest(int[,] input, int[,] expectedResult, MatrixSorter.SortingDirection direction)
        {
            var result = MatrixSorter.BubbleSort(input, SortingMethod.CompareMinElementsInRows, direction);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(null, typeof(ArgumentNullException))]
        public void SortExceptionTest(int[,] testMatrix, Type expectedEx)
        {
            Assert.Throws(Is.TypeOf(expectedEx),
                () => MatrixSorter.BubbleSort(testMatrix, SortingMethod.CompareMaxElementsInRows, MatrixSorter.SortingDirection.Ascending));
        }
    }
}