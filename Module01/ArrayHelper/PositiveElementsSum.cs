using System;

namespace ArrayHelper
{
    public class PositiveElementsSum
    {
        public static int SumOfElements(int[,] arrayWithNumbers)
        {
            if (arrayWithNumbers == null) 
                throw new ArgumentNullException($"The array is null");
            var positiveElementsSum = 0;
            foreach (var number in arrayWithNumbers)
            {
                if (number > 0) positiveElementsSum += number;
            }
            return positiveElementsSum;
        }
    }
}
