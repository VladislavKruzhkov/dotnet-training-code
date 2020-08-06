using System;
using ArrayHelper;
using RectangleHelper;

namespace ConsoleAppM01
{
    public class Program
    {
        public static void PrintSum(int positiveElementsSum)
        {
            Console.WriteLine($"Sum of positive elements of the array is {positiveElementsSum}");
        }
        
        public static void Main(string[] args)
        {
            var positiveNumbers = new[] { 1, 2, 5, 2, 7, 2, 3, 4 };
            ArraySorter.Sort(positiveNumbers, ArraySorter.SortOrder.Asc);
            ArraySorter.PrintArray(positiveNumbers);
            ArraySorter.Sort(positiveNumbers, ArraySorter.SortOrder.Desc);
            ArraySorter.PrintArray(positiveNumbers);

            var Numbers = new[] { 4143, 325, -5, 263, 0, 2513, 63, 411111 };
            ArraySorter.Sort(Numbers, ArraySorter.SortOrder.Asc);
            ArraySorter.PrintArray(Numbers);
            ArraySorter.Sort(Numbers, ArraySorter.SortOrder.Desc);
            ArraySorter.PrintArray(Numbers);

            int[,] arraySumOfElements = { { 3, 1, 2 }, { 3, 4, 5 }, { -3, -2, -1 } };
            var positiveElementsSum = PositiveElementsSum.SumOfElements(arraySumOfElements);
            PrintSum(positiveElementsSum);

            try
            {
                int[,] arrayOfNulls = null;
                Console.WriteLine(PositiveElementsSum.SumOfElements(arrayOfNulls));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            var rectangle1 = new Rectangle(1, 2);
            var rectangle2 = new Rectangle(12, 3);

            Console.WriteLine($"Perimeter of the rectangle is {rectangle1.Perimeter}");
            Console.WriteLine($"Square of the rectangle is {rectangle1.Square}");
            
            Console.WriteLine($"Perimeter of the rectangle is {rectangle2.Perimeter}");
            Console.WriteLine($"Square of the rectangle is {rectangle2.Square}");

            Console.ReadLine();
        }
    }
}
