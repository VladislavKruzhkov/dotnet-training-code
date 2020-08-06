using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public class FibonacciNumbers
    {
        public IEnumerable<int> GetFibonacciNumbers(int number)
        {
            if (number < 0)
                throw new ArgumentException();

            var preLast = 0;
            var last = 1;

            if (number > 0)
            {
                yield return preLast;

                if (number > 1) yield return last;
            }

            for (var i = 2; i < number; ++i)
            {
                var next = checked(last + preLast);
                yield return next;
                preLast = last;
                last = next;
            }
        }
    }
}
