using System;

namespace Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new ReversePolishCalculator();
            Console.WriteLine("Enter string in Reverse Polish notation to calculate it");
            var evaluation = Console.ReadLine();
            Console.WriteLine("Result is:");
            try
            {
                Console.WriteLine(calculator.Calculate(evaluation));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
