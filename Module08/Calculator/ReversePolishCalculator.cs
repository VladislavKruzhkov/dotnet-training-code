using System;
using System.Linq;
using Collections;

namespace Calculator
{
    public class ReversePolishCalculator
    {
        private readonly string[] _signs = { "+", "-", "*", "/" };

        public double Calculate(string inputExpression)
        {
            if (string.IsNullOrEmpty(inputExpression)) return 0;

            var numbersAndSigns = inputExpression.Split(" ");

            var stack = new MyStack<double>();

            foreach (var element in numbersAndSigns)
            {
                if (IsNumber(element)) stack.Push(double.Parse(element));

                else if (IsSign(element))
                {
                    if (stack.Count < 2)
                        throw new FormatException("Format of entered string is invalid");

                    CalculateOperation(stack, element);
                }
                else throw new ArgumentException("Wrong input");
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            throw new FormatException("Format of entered string is invalid");
        }

        #region PrivateMethods

        private bool IsNumber(string element)
        {
            return double.TryParse(element, out _);
        }

        private bool IsSign(string element)
        {
            return (_signs.Contains(element));
        }

        private void CalculateOperation(MyStack<double> stack, string operation)
        {
            switch (operation)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    stack.Push(-stack.Pop() + stack.Pop());
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "/":
                    if (Math.Abs(stack.Peek()) < double.Epsilon)
                        throw new DivideByZeroException();

                    stack.Push(1/(stack.Pop() / stack.Pop()));
                    break;
            }
        }
        #endregion
    }
}
