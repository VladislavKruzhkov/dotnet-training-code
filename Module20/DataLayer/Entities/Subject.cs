using System.Collections.Generic;

namespace DataLayer.Entities
{
    
    public class Subject
    {
        public int SubjectId { get; set; }

        public string? Name { get; set; }

        public int ProfessorId { get; set; }
        public virtual Professor? Professor { get; set; }

        public virtual List<Attendance> Attendance { get; set; } = new List<Attendance>();
    }
}
