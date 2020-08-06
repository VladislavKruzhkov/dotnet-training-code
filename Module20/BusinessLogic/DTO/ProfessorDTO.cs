using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class ProfessorDTO
    {
        public int ProfessorId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public List<SubjectDTO> Subjects { get; set; } = new List<SubjectDTO>();
    }
}
