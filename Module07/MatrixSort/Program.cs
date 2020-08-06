using System;

namespace MatrixSort
{
    public class Program
    {
        private static readonly int[,] Matrix =
        {
            {0, 8, 7},
            {2, 9, 8},
            {5, 6, 1},
            {4, 7, 2},
        };
        
        public static void Main(string[] args)
        {
            Console.WriteLine("The matrix");
            PrintMatrix(Matrix);

            try
            {
                var sortOrder = ChooseSortOrderByUser();
                var sortMethod = ChooseSortingMethodByUser();
                var sortedMatrix = MatrixSorter.BubbleSort(Matrix, sortMethod, sortOrder);

                Console.WriteLine("The sorted matrix");
                PrintMatrix(sortedMatrix);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        #region PrivateMethods

        private static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix.GetLength(1); ++j)
                    Console.Write($"{matrix[i, j]} ");

                Console.WriteLine();
            }
        }

        private static MatrixSorter.SortingDirection ChooseSortOrderByUser()
        {
            Console.WriteLine("Which order would you like to sort in?");
            Console.WriteLine("0 - Descending");
            Console.WriteLine("1 - Ascending");

            var sortOrder = Console.ReadLine() switch
            {
                "0" => MatrixSorter.SortingDirection.Descending,
                "1" => MatrixSorter.SortingDirection.Ascending,
                _ => throw new ArgumentException("Entered invalid sort order")
            };
            return sortOrder;
        }

        private static MatrixSorter.SortMethod ChooseSortingMethodByUser()
        {
            Console.WriteLine("What would you like to compare?");
            Console.WriteLine("1 - Sum of elements in rows");
            Console.WriteLine("2 - Min elements in rows");
            Console.WriteLine("3 - Max elements in rows");

            return Console.ReadLine() switch
            {
                "1" => SortingMethod.CompareSumOfElementsInRows,
                "2" => SortingMethod.CompareMinElementsInRows,
                "3" => SortingMethod.CompareMaxElementsInRows,
                _ => throw new ArgumentException("Entered invalid sorting method")
            };
        }
        #endregion
    }
}
