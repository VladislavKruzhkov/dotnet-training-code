using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public List<Attendance> Attendance { get; set; } = new List<Attendance>();
    }
}
