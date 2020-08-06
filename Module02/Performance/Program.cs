using System;
using System.Diagnostics;

namespace Performance
{
    public class Program
    {
        private static readonly Random Rand = new Random();

        public static C[] ClassesInit()
        {
            C[] classes = new C[100000];
            for (int element = 0; element < 100000; element++)
            {
                classes[element] = new C { i = Rand.Next() };
            }
            return classes;
        }

        public static S[] StructsInit()
        {
            S[] structs = new S[100000];
            for (int element = 0; element < 100000; element++)
            {
                structs[element] = new S { i = Rand.Next() };
            }
            return structs;
        }

        public static void InitMemoryComparison(long deltaStructInit, long deltaClassInit)
        {
            Console.WriteLine($"Delta struct initialization: {deltaStructInit}");
            Console.WriteLine($"Delta classes initialization: {deltaClassInit}");
            var initMemoryDifference = deltaClassInit - deltaStructInit;
            Console.WriteLine($"Delta classes initialization - Delta struct initialization is equal to {initMemoryDifference}");
        }

        public static void SortTimeComparison(S[] structs, C[] classes)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            Array.Sort(structs, (x, y) => x.i.CompareTo(y.i));
            stopWatch.Stop();
            Console.WriteLine($"Structs sort time: {stopWatch.Elapsed}");
            stopWatch.Reset();

            stopWatch.Start();
            Array.Sort(classes, (x, y) => x.i.CompareTo(y.i));
            stopWatch.Stop();
            Console.WriteLine($"Classes sort time: {stopWatch.Elapsed}");
        }

        public static void Main(string[] args)
        {
            Process myProcess = Process.GetCurrentProcess();

            var beforeStructInit = myProcess.PrivateMemorySize64;
            var structs = StructsInit();
            myProcess.Refresh();
            var afterStructInit = myProcess.PrivateMemorySize64;
            var deltaStructInit = afterStructInit - beforeStructInit;

            myProcess.Refresh();
            var beforeClassInit = myProcess.PrivateMemorySize64;
            var classes = ClassesInit();
            myProcess.Refresh();
            var afterClassInit = myProcess.PrivateMemorySize64;
            var deltaClassInit = afterClassInit - beforeClassInit;

            InitMemoryComparison(deltaStructInit, deltaClassInit);
            SortTimeComparison(structs, classes);

            Console.ReadKey();
        }
    }
}
