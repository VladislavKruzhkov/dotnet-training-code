using System;
using System.Collections.Generic;
using System.Linq;

namespace M09ConsoleApp
{
    public class Program
    {
        public static void PrintTests(IEnumerable<StudentWithTest> filteredStudentsAndTests)
        {
            foreach (var student in filteredStudentsAndTests)
            {
                Console.WriteLine($"{student.Name} {student.Surname} {student.Subject} {student.Date.ToShortDateString()} {student.Mark}");
            }
        }

        public static void Main(string[] args)
        {
            var dataFilter = new DataFilter();
            Console.WriteLine("Hello! Please input your criteria.");
            Console.WriteLine("Available flags:");
            Console.WriteLine("-name 'name' -surname 'surname' -test 'testname'");
            Console.WriteLine("-datefrom 'dd/MM/yyyy' -dateto 'dd/MM/yyyy'");
            Console.WriteLine("-minmark 'mark' -maxmark 'mark'");
            Console.WriteLine("-sort name/surname/subject/mark/date asc/dsc");
            Console.WriteLine();

            var criteria = Console.ReadLine();
            try
            {
                List<StudentWithTest> filteredStudentsAndTests = dataFilter.GetTestsData(criteria, Constants.Path).ToList();

                if (!filteredStudentsAndTests.Any()) Console.WriteLine("There are not students and tests with such criteria");
                else
                {
                    PrintTests(filteredStudentsAndTests);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}