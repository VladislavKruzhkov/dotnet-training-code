using System;
using System.Linq;

namespace MatrixSort
{
    public static class SortingMethod
    {
        public static int CompareSumOfElementsInRows(int[] row1, int[] row2)
        {
            if (row1 == null || row2 == null)
                throw new ArgumentNullException();

            return row1.Sum().CompareTo(row2.Sum());
        }

        public static int CompareMinElementsInRows(int[] row1, int[] row2)
        {
            if (row1 == null || row2 == null)
                throw new ArgumentNullException();

            return row1.Min().CompareTo(row2.Min());
        }

        public static int CompareMaxElementsInRows(int[] row1, int[] row2)
        {
            if (row1 == null || row2 == null)
                throw new ArgumentNullException();

            return row1.Max().CompareTo(row2.Max());
        }
    }
}
