using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace DataLayer.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        [XmlIgnore]
        public virtual Student? Student { get; set; }

        public int SubjectId { get; set; }

        [XmlIgnore]
        public virtual Subject? Subject { get; set; }

        public bool IsStudentOnLecture { get; set; }

        [Range(0, 5)]
        public int Mark { get; set; }
    }
}
