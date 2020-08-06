using System;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Strings
{
    public static class Summator
    {
        private static string _minus = "-";

        public static string ReverseNumber(StringBuilder sumBuilder)
        {
            for (var digit = 0; digit < sumBuilder.Length / 2; digit++)
            {
                var tmp = sumBuilder[digit];
                sumBuilder[digit] = sumBuilder[sumBuilder.Length - 1 - digit];
                sumBuilder[sumBuilder.Length - 1 - digit] = tmp;
            }
            return sumBuilder.ToString();
        }

        public static void CompareNumbers(ref string leftNumber, ref string rightNumber, ref bool numberOneNegative)
        {
            for (var digit = 0; digit < leftNumber.Length; digit++)
            {
                if (leftNumber[digit] < rightNumber[digit])
                {
                    SwapNumbers(ref leftNumber, ref rightNumber);
                    numberOneNegative = !numberOneNegative;
                }
            }
        }

        public static StringBuilder SubtractNumbers(int[] leftNumber, int[] rightNumber)
        {
            StringBuilder sumBuilder = new StringBuilder();
            for (var digit = rightNumber.Length - 1; digit >= 0; digit--)
            {
                var digitDifference = leftNumber.Length - rightNumber.Length;
                var differenceOfDigit = leftNumber[digit + digitDifference] - rightNumber[digit];
                if (differenceOfDigit < 0)
                {
                    differenceOfDigit = leftNumber[digit + digitDifference] + 10 - rightNumber[digit];
                    sumBuilder = sumBuilder.Append(differenceOfDigit);
                    if (digitDifference == 0 && digit == 0) sumBuilder = sumBuilder.Append("1");
                    else leftNumber[digitDifference + digit - 1] -= 1;
                }
                else sumBuilder = sumBuilder.Append(differenceOfDigit);
            }
            return sumBuilder;
        }
        
        public static void SwapNumbers(ref string leftNumber, ref string rightNumber)
        {
            var tmp = leftNumber;
            leftNumber = rightNumber;
            rightNumber = tmp;
        }

        public static string IdenticalSigns(string leftNumber, string rightNumber)
        {
            bool numbersNegative = false;
            if (leftNumber[0].ToString() == _minus)
            {
                leftNumber = leftNumber.Remove(0, 1);
                rightNumber = rightNumber.Remove(0, 1);
                numbersNegative = true;
            }
            CompareNumbersLength(ref leftNumber, ref rightNumber);
            var numberArrayRepresentation1 = StringToIntArray(leftNumber);
            var numberArrayRepresentation2 = StringToIntArray(rightNumber);

            StringBuilder sumBuilder = new StringBuilder();

            var digitDifference = leftNumber.Length - rightNumber.Length;
            for (var digit = numberArrayRepresentation2.Length - 1; digit >= 0; digit--)
            {
                var sumOfDigit = numberArrayRepresentation1[digit + digitDifference] + numberArrayRepresentation2[digit];
                if (sumOfDigit >= 10)
                {
                    sumOfDigit -= 10;
                    sumBuilder = sumBuilder.Append(sumOfDigit);
                    if (digitDifference == 0 && digit == 0) sumBuilder = sumBuilder.Append("1");
                    else numberArrayRepresentation1[digitDifference + digit - 1] += 1;
                }
                else sumBuilder = sumBuilder.Append(sumOfDigit);
            }

            for (var digit = digitDifference - 1; digit >= 0; digit--)
            {
                sumBuilder = sumBuilder.Append(numberArrayRepresentation1[digit]);
            }
            if (numbersNegative) sumBuilder = sumBuilder.Append(_minus);

            return ReverseNumber(sumBuilder);
        }

        public static string DifferentSigns(string leftNumber, string rightNumber)
        {
            bool numberOneNegative = leftNumber[0].ToString() == _minus;
            if (numberOneNegative) leftNumber = leftNumber.Remove(0, 1);
            else rightNumber = rightNumber.Remove(0, 1);

            if (leftNumber.Length < rightNumber.Length)
            {
                SwapNumbers(ref leftNumber, ref rightNumber);
                numberOneNegative = !numberOneNegative;
            }

            var digitDifference = leftNumber.Length - rightNumber.Length;
            if (digitDifference == 0) CompareNumbers( ref leftNumber, ref rightNumber, ref numberOneNegative);

            var numberArrayRepresentation1 = StringToIntArray(leftNumber);
            var numberArrayRepresenrarion2 = StringToIntArray(rightNumber);

            StringBuilder sumBuilder = SubtractNumbers(numberArrayRepresentation1,numberArrayRepresenrarion2);

            for (var digit = digitDifference - 1; digit >= 0; digit--)
            {
                sumBuilder = sumBuilder.Append(numberArrayRepresentation1[digit]);
            }
            if (numberOneNegative) sumBuilder = sumBuilder.Append(_minus);

            return ReverseNumber(sumBuilder);
        }

        public static bool CheckSigns(string leftNumber, string stringNumber2)
        {
            if (leftNumber[0] != '-' && stringNumber2[0] != '-') return true;
            if (leftNumber[0] == '-' && stringNumber2[0] == '-') return true;
            return false;
        }

        public static void CompareNumbersLength(ref string leftNumber, ref string rightNumber)
        {
            if (leftNumber.Length < rightNumber.Length)
            {
                SwapNumbers(ref leftNumber, ref rightNumber);
            }
        }

        public static int[] StringToIntArray(string number)
        {
            int[] numberArrayRepresentation = new int[number.Length];
            for (var digit = 0; digit < number.Length; digit++)
            {
                numberArrayRepresentation[digit] = int.Parse(number[digit].ToString());
            }
            return numberArrayRepresentation;
        }

        public static string Sum(string leftNumber, string rightNumber)
        {
            if (String.IsNullOrEmpty(leftNumber)) 
                throw new ArgumentException(nameof(leftNumber));

            if (String.IsNullOrEmpty(rightNumber))
                throw new ArgumentException(nameof(rightNumber));

            return CheckSigns(leftNumber, rightNumber)
                ? IdenticalSigns(leftNumber, rightNumber)
                : DifferentSigns(leftNumber, rightNumber);
        }
    }
}
