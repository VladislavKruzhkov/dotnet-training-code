using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class BinarySearcher<T>
    {
        public static int Search(T item, T[] list, IComparer<T> comparer)
        {
            if(item == null || list == null || list.Length == 0)
                throw new ArgumentException();

            var bottom = 0;
            var top = list.Length - 1;
            
            while (top >= bottom)
            {
                var middle = (bottom + top) / 2;
                switch (comparer.Compare(list[middle], item))
                {
                    case 0: 
                        return middle;
                    case 1: 
                        top = middle;
                        break;
                    case -1:
                        bottom = middle + 1;
                        break;
                }
            }
            return -1;
        }
    }
}
