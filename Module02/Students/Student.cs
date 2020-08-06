using System;

namespace Students
{
    public class Student
    {
        private void FullNameFromEmail(string email)
        {
            email = email.Remove(Email.IndexOf("@"));

            string[] nameAndSurname = email.Split('.');

            nameAndSurname[0] = FirstLetterToUpper(nameAndSurname[0]);
            nameAndSurname[1] = FirstLetterToUpper(nameAndSurname[1]);

            FullName = nameAndSurname[0] + " " + nameAndSurname[1];
        }
        private static bool IsEmailValid(string email)
        {
            if (email == null) return false;
            if (email.IndexOf(".") < 0) return false;
            if (email.IndexOf("@") < 0) return false;
            return true;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Student's full name is {FullName}");
            Console.WriteLine($"Student's Email is {Email}");
        }

        public string FirstLetterToLower(string word)
        {
            word = word.Insert(0, word[0].ToString().ToLower());
            word = word.Remove(1, 1);
            return word;
        }

        public string FirstLetterToUpper(string word)
        {
            word = word.Insert(0, word[0].ToString().ToUpper());
            word = word.Remove(1, 1);
            return word;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Student student) return Equals(student);
            return false;
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode() ^ Email.GetHashCode();
        }

        public bool Equals(Student p)
        {
            if (ReferenceEquals(p, null)) return false;

            if (ReferenceEquals(this, p)) return true;

            if (this.GetType() != p.GetType()) return false;

            return (FullName.Equals(p.FullName)) && (Email.Equals(p.Email));
        }

        public Student(string email)
        {
            if (!IsEmailValid(email))
                throw new ArgumentException("Email is not valid");

            Email = email;
            FullNameFromEmail(email);
        }

        public Student(string name, string surname)
        {
            if (name.Equals(null) || surname.Equals(null))
                throw new NullReferenceException("Name or surname is null");
            FullName = name + " " + surname;

            name = FirstLetterToLower(name);
            surname = FirstLetterToLower(surname);

            Email = name + "." + surname + "@epam.com";
        }

        public string FullName { get; set; }

        public string Email { get; }
    }
}
