using System;

namespace MatrixSort
{
    public static class MatrixSorter
    {
        public delegate int SortMethod(int[] row1, int[] row2);

        public static int[,] BubbleSort(int[,] matrix, SortMethod sortMethod, SortingDirection direction)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j + 1 < matrix.GetLength(0); j++)
                {
                    var compareResult = sortMethod(GetRow(matrix, i), GetRow(matrix, j));

                    if ((direction == SortingDirection.Ascending && compareResult == -1)
                        || (direction == SortingDirection.Descending && compareResult == 1))
                    {
                        SwapRows(matrix, i, j);
                    }
                }
            }
            return matrix;
        }

        public enum SortingDirection
        {
            Ascending,
            Descending,
        }

        #region PrivateMethods

        private static int[] GetRow(int[,] matrix, int rowNumber)
        {
            var row = new int[matrix.GetLength(1)];
            for (var element = 0; element < matrix.GetLength(1); element++)
            {
                row[element] = matrix[rowNumber, element];
            }
            return row;
        }

        private static void SwapRows(int[,] matrix, int row1, int row2)
        {
            for (var element = 0; element < matrix.GetLength(1); element++)
            {
                var tmp = matrix[row1, element];
                matrix[row1, element] = matrix[row2, element];
                matrix[row2, element] = tmp;
            }
        }
        #endregion
    }
}
