using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearch;
using Collections;
using Fibonacci;

namespace ConsoleApp
{
    public class Program
    {
        public static void BinarySearchRun()
        {
            Console.WriteLine("Enter array of numbers:");
            var numbers = Console.ReadLine();
            
            if (string.IsNullOrEmpty(numbers)) 
                throw new ArgumentException("The string is null or empty");

            var numbersList = numbers.Split(' ').ToList();

            if(!numbersList.Any(x => int.TryParse(x, out _)))
                throw new ArgumentException("Wrong input");

            var numbersArray = new int[numbersList.Count];

            for (var number = 0; number < numbersList.Count; number++)
            {
                numbersArray[number] = int.Parse(numbersList[number]);
            }

            Console.WriteLine("Enter number to search");

            var numberToSearch = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());

            var result = BinarySearcher<int>.Search(numberToSearch, numbersArray, Comparer<int>.Default);
            Console.WriteLine($"Index of the number is {result}");
        }

        public static void FibonacciRun()
        {
            var fibonacci = new FibonacciNumbers();

            Console.WriteLine("Enter number of Fibonacci number series");

            var number = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException());

            var fibonacciList = fibonacci.GetFibonacciNumbers(number).ToList();

            Console.WriteLine($"Fibonacci number series of {number} numbers");
            
            foreach (var num in fibonacciList)
                Console.Write($"{num} ");

            Console.WriteLine();
        }

        public static void StackRun()
        {
            Console.WriteLine("Adding numbers from 1 to 10 to stack with Push");
            var myStack = new MyStack<int>();

            for (var element = 1; element <= 10; element++)
            {
                myStack.Push(element);
            }

            Console.WriteLine("Using Peek");
            Console.WriteLine(myStack.Peek());

            Console.WriteLine("Using Pop");
            myStack.Pop();

            Console.WriteLine("Resulting stack");
            foreach (var element in myStack)
            {
                Console.Write($"{element} ");
            }
        }

        public static void QueueRun()
        {
            Console.WriteLine("Adding numbers from 1 to 10 to Queue with Enqueue");
            var myQueue = new MyQueue<int>();

            for (var element = 1; element <= 10; element++)
            {
                myQueue.Enqueue(element);
            }

            Console.WriteLine("Using Peek");
            Console.WriteLine(myQueue.Peek());

            Console.WriteLine("Using Pop");
            myQueue.Dequeue();

            Console.WriteLine("Resulting Queue");
            foreach (var element in myQueue)
            {
                Console.Write($"{element} ");
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                BinarySearchRun();
                FibonacciRun();
                StackRun();
                Console.WriteLine();
                QueueRun();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
