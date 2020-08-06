using System;
using Microsoft.Extensions.Logging;

namespace Module05
{
    public class Converter
    {
        private readonly ILogger<Converter> _logger;

        private bool _negative;

        public Converter(ILogger<Converter> logger = null)
        {
            _logger = logger;
        }

        public int ConvertToIntNumber(string number)
        {
            _logger?.LogDebug($"String.ToInt method executed. Entered string: {number}");

            if (number == null)
                throw new ArgumentNullException(nameof(number));

            if (number == "")
                throw new ArgumentException($"The string '{number}' has an incorrect format");

            _logger?.LogDebug("Converting string to CharArray");
            char[] numberToArray;
            if (number[0] == Minus)
            {
                _negative = true;
                numberToArray = number.ToCharArray(1, number.Length - 1);
            }
            else
            {
                _negative = false;
                numberToArray = number.ToCharArray();
            }

            if (!IsNumberCorrect(numberToArray))
                throw new ArgumentException($"The string '{number}' has an incorrect format");

            return ArrayNumberToInt(numberToArray);
        }

        #region PrivateMethods

        private const char Minus = '-';

        private int ArrayNumberToInt(char[] numberToArray)
        {
            _logger?.LogDebug("Converting CharArray to Int");
            var resultNumber = 0;
            foreach (var digit in numberToArray)
            {
                checked
                {
                    resultNumber *= 10;
                    resultNumber += digit - '0';
                }
            }
            if (_negative) resultNumber *= -1;
            _logger?.LogDebug("Number is successfully converted");
            return resultNumber;
        }

        private bool IsNumberCorrect(char[] numberToArray)
        {
            _logger?.LogDebug("Checking if number is correct");

            foreach (var digit in numberToArray)
            {
                if (!char.IsDigit(digit)) return false;
            }
            return true;
        }
        #endregion
    }
}