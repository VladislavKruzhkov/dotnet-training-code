using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using M09ConsoleApp;

namespace DataFilterTest
{
    public class DataFilterTest
    {
        private static readonly List<TestCaseData> GetTestsData_TestData =
           new List<TestCaseData>(new[]
           {
               new TestCaseData(
                   "-name Vladislav -test History",
                   new List<StudentWithTest>
                   {
                       new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "History", Mark = 5,
                           Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)}
                   }),

               new TestCaseData(
                    "-name Vladislav",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "History", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "IT", Mark = 5,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)}
                    }),

                new TestCaseData(
                    "-name Vladislav -surname Krutkov -maxmark 5 -minmark 5 -datefrom 25/09/2012 -dateto 25/09/2012",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)}
                    }
                ),

                new TestCaseData(
                    "-minmark 3 -maxmark 5 -datefrom 25/09/2012 -dateto 20/12/2012",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Maths", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Physics", Mark = 3,
                            Date = DateTime.ParseExact("20/12/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Russian", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Maths", Mark = 3,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Literature", Mark = 3,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "IT", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "History", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "IT", Mark = 5,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)}
                    }
                ),

                new TestCaseData(
                    "-test Physics",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Physics", Mark = 3,
                            Date = DateTime.ParseExact("20/12/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)}
                    }
                ),

                new TestCaseData(
                    "-sort date asc",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Literature", Mark = 3,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Maths", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Maths", Mark = 3,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "History", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Russian", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "IT", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "IT", Mark = 5,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Physics", Mark = 3,
                            Date = DateTime.ParseExact("20/12/2012", Constants.DateTimeFormat, null)}
                    }
                ),

                new TestCaseData(
                    "-sort mark dsc",
                    new List<StudentWithTest>
                    {
                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "IT", Mark = 5,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "Physics", Mark = 5,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Vladislav", Surname = "Krutkov", Subject = "History", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Maths", Mark = 5,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "IT", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Russian", Mark = 4,
                            Date = DateTime.ParseExact("23/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Literature", Mark = 3,
                            Date = DateTime.ParseExact("25/09/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Grisha", Surname = "Ivanov", Subject = "Maths", Mark = 3,
                            Date = DateTime.ParseExact("20/11/2012", Constants.DateTimeFormat, null)},

                        new StudentWithTest {Name = "Ivan", Surname = "Petrov", Subject = "Physics", Mark = 3,
                            Date = DateTime.ParseExact("20/12/2012", Constants.DateTimeFormat, null)}

                    }
                )
           });

        [TestCaseSource(nameof(GetTestsData_TestData))]
        public void GetTestsData_ValidParameters_CorrectResult(string criteria, List<StudentWithTest> expectedResult)
        {
            var dataFilter = new DataFilter();

            var result = dataFilter.GetTestsData(criteria, Constants.Path).ToList();

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(null, typeof(NullReferenceException))]
        [TestCase("-hkh Ivan", typeof(FormatException))]
        [TestCase("hkh", typeof(FormatException))]
        [TestCase("-sort nam asc", typeof(FormatException))]
        [TestCase("-sort name as", typeof(FormatException))]
        public void GetTestsData_InvalidParameters_Exception(string criteria, Type expectedEx)
        {
            var dataHandler = new DataFilter();

            void Result() => dataHandler.GetTestsData(criteria, Constants.Path).ToList();

            Assert.Throws(expectedEx, Result);
        }
    }
}
