using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DTO
{
    public class StudentDTO
    {
        [Required]
        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }
    }
}
