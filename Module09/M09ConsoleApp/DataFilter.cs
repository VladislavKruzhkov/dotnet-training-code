using System;
using System.Collections.Generic;
using System.Linq;

namespace M09ConsoleApp
{
    public class DataFilter
    {
        private readonly Dictionary<string, string> _criteriaDictionary = new Dictionary<string, string>
        {
            ["-name"] = "",
            ["-surname"] = "",
            ["-minmark"] = "",
            ["-maxmark"] = "",
            ["-datefrom"] = "",
            ["-dateto"] = "",
            ["-test"] = "",
            ["-sort"] = ""
        };

        private string _sortCriteria = "";

        private string _sortOrder = "";

        public IEnumerable<StudentWithTest> GetTestsData(string inputCriteria, string dataPath)
        {
            ApplyCriteria(inputCriteria);

            var receiver = new DataReceiver();

            var students = receiver.DeserializeData(dataPath);

            var filteredStudentsAndTests = FilterData(students);

            var sortedStudentsAndTests = SortTests(filteredStudentsAndTests);

            return sortedStudentsAndTests;
        }

        #region PrivateMethods

        private void ApplyCriteria(string inputCriteria)
        {
            var criteriaArray = inputCriteria.Split(' ');

            if (criteriaArray.Length % 2 == 0 && criteriaArray.Contains("-sort")
                || criteriaArray.Length % 2 != 0 && !criteriaArray.Contains("-sort"))
            {
                throw new FormatException("Invalid input criteria");
            }

            for (var element = 0; element < criteriaArray.Length; element++)
            {
                if (criteriaArray[element].StartsWith('-'))
                {
                    if (element + 1 == criteriaArray.Length)
                        throw new FormatException("Invalid input criteria");

                    if (!_criteriaDictionary.ContainsKey(criteriaArray[element]))
                        throw new FormatException($"Criteria {criteriaArray[element]} not found");

                    if (criteriaArray[element] == "-sort")
                    {
                        if (element + 2 == criteriaArray.Length)
                            throw new FormatException("Invalid sort criteria");
                        
                        _sortCriteria = criteriaArray[element + 1];
                        _sortOrder = criteriaArray[element + 2];
                        element += 2;
                    }
                    else _criteriaDictionary[criteriaArray[element]] = criteriaArray[element + 1];
                }
            }
        }

        private IEnumerable<StudentWithTest> FilterData(List<Student> students)
        {
            var filteredStudents = students
                .Where(student => CheckConformityStudent(student))
                .SelectMany(student => student.Tests, ((student, test) => new StudentWithTest
                {
                    Name = student.Name,
                    Surname = student.Surname,
                    Subject = test.Subject,
                    Mark = test.Mark,
                    Date = test.Date
                }))
                .Where(studentAndTest => CheckConformityTests(studentAndTest));
            return filteredStudents;
        }

        private bool CheckConformityStudent(Student student)
        {
            if (!string.IsNullOrEmpty(_criteriaDictionary["-name"]) &&
                _criteriaDictionary["-name"] != student.Name) return false;

            if (!string.IsNullOrEmpty(_criteriaDictionary["-surname"]) &&
                _criteriaDictionary["-surname"] != student.Surname) return false;
            return true;
        }

        private bool CheckConformityTests(StudentWithTest test)
        {
            if (!string.IsNullOrEmpty(_criteriaDictionary["-test"]) &&
                _criteriaDictionary["-test"] != test.Subject) return false;

            if (!string.IsNullOrEmpty(_criteriaDictionary["-minmark"]) &&
                int.Parse(_criteriaDictionary["-minmark"]).CompareTo(test.Mark) == 1) return false;

            if (!string.IsNullOrEmpty(_criteriaDictionary["-maxmark"]) &&
                int.Parse(_criteriaDictionary["-maxmark"]).CompareTo(test.Mark) == -1) return false;

            if (!string.IsNullOrEmpty(_criteriaDictionary["-datefrom"]) &&
                DateTime.Parse(_criteriaDictionary["-datefrom"]).CompareTo(test.Date) == 1) return false;

            if (!string.IsNullOrEmpty(_criteriaDictionary["-dateto"]) &&
                DateTime.Parse(_criteriaDictionary["-dateto"]).CompareTo(test.Date) == -1) return false;

            return true;
        }

        private IEnumerable<StudentWithTest> SortTests(IEnumerable<StudentWithTest> filteredStudentsAndTests)
        {
            if (!string.IsNullOrEmpty(_sortCriteria) && !string.IsNullOrEmpty(_sortCriteria))
            {
                filteredStudentsAndTests = _sortCriteria switch
                {
                    "name" => filteredStudentsAndTests.OrderBy(studentAndTest => studentAndTest.Name),
                    "surname" => filteredStudentsAndTests.OrderBy(studentAndTest => studentAndTest.Surname),
                    "subject" => filteredStudentsAndTests.OrderBy(studentAndTest => studentAndTest.Subject),
                    "mark" => filteredStudentsAndTests.OrderBy(studentAndTest => studentAndTest.Mark),
                    "date" => filteredStudentsAndTests.OrderBy(studentAndTest => studentAndTest.Date),
                    _ => throw new FormatException($"Was entered invalid sorting criteria: {_sortCriteria}")
                };

                filteredStudentsAndTests = _sortOrder switch
                {
                    "asc" => filteredStudentsAndTests,
                    "dsc" => filteredStudentsAndTests.Reverse(),
                    _ => throw new FormatException($"Was entered invalid sorting criteria: {_sortOrder}'")
                };
            }
            return filteredStudentsAndTests;
        }
        #endregion
    }
}
