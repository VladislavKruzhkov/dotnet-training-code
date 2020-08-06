using System;
using System.Collections.Generic;

namespace Students
{
    public class Program
    {
        private static Dictionary<Student, HashSet<string>> StudentSubjectDict = new Dictionary<Student, HashSet<string>>();

        private static readonly string[] Subjects = { "Maths", "PE", "IT", "Biology", "English", "Russian" };

        private static void FillThreeRandomSubjectsForStudent(Student student)
        {
            var rand = new Random();
            StudentSubjectDict[student] = new HashSet<string> { Subjects[rand.Next(5)], Subjects[rand.Next(5)], Subjects[rand.Next(5)] };
        }

        public static void Main(string[] args)
        {
            var studentLevTigrov1 = new Student("Lev", "Tigrov");
            var studentLevTigrov2 = new Student("lev.tigrov@epam.com");
            studentLevTigrov1.PrintInfo();
            studentLevTigrov2.PrintInfo();

            var studentVladislavKruzhkov1 = new Student("vladislav.kruzhkov@epam.com");
            var studentVladislavKruzhkov2 = new Student("Vladislav", "Kruzhkov");
            studentVladislavKruzhkov1.PrintInfo();
            studentVladislavKruzhkov2.PrintInfo();

            var studentSanyaKononov1 = new Student("Sanya", "Kononov");
            var studentSanyaKononov2 = new Student("sanya.kononov@epam.com");
            studentSanyaKononov1.PrintInfo();
            studentSanyaKononov2.PrintInfo();

            FillThreeRandomSubjectsForStudent(studentLevTigrov1);
            FillThreeRandomSubjectsForStudent(studentLevTigrov2);
            FillThreeRandomSubjectsForStudent(studentVladislavKruzhkov1);
            FillThreeRandomSubjectsForStudent(studentVladislavKruzhkov2);
            FillThreeRandomSubjectsForStudent(studentSanyaKononov1);
            FillThreeRandomSubjectsForStudent(studentSanyaKononov2);

            Console.WriteLine(studentVladislavKruzhkov1.Equals(studentVladislavKruzhkov2));
            Console.WriteLine(studentVladislavKruzhkov1.Equals(studentLevTigrov1));

            Console.WriteLine(studentLevTigrov1.GetHashCode());
            Console.WriteLine(studentLevTigrov2.GetHashCode());

            Console.ReadLine();
        }
    }
}
