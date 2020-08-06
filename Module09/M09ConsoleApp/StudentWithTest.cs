using System;

namespace M09ConsoleApp
{
    public class StudentWithTest : IEquatable<StudentWithTest>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Subject { get; set; }

        public int Mark { get; set; }

        public DateTime Date { get; set; }


        public bool Equals(StudentWithTest? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Surname == other.Surname && Subject == other.Subject && Mark == other.Mark && Date.Equals(other.Date);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StudentWithTest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Subject, Mark, Date);
        }
    }
}
