using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.DTO
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }

        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public bool IsStudentOnLecture { get; set; }

        [Range(0, 5)]
        public int Mark { get; set; }
    }
}
