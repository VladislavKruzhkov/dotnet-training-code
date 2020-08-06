using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
