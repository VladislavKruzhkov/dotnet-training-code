using System;

namespace ArrayHelper
{
    public static class ArraySorter
    {
        public enum SortOrder
        {
            Asc,
            Desc
        }

        public static void Sort(int[] arrayToSort, SortOrder sortOrder = SortOrder.Asc)
        {
            if (arrayToSort == null)
                throw new ArgumentNullException($"The array is null");
            for (var i = 0; i < arrayToSort.Length; i++)
            {
                for (var j = i + 1; j < arrayToSort.Length; j++)
                {
                    var sortCondition = sortOrder == SortOrder.Asc
                        ? arrayToSort[i] > arrayToSort[j]
                        : arrayToSort[i] < arrayToSort[j];
                    if (sortCondition)
                    {
                        var temp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[j];
                        arrayToSort[j] = temp;
                    }
                }
            }
        }

        public static void PrintArray(int[] array)
        {
            if (array == null)
                throw new ArgumentException($"The array is empty");
            Console.WriteLine($"Sorted array:");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) Console.Write($"{array[i]}\n");
                else Console.Write($"{array[i]} ");
            }
        }
    }
}
