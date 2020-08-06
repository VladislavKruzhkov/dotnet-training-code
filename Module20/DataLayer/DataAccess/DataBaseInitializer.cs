using DataLayer.Entities;

namespace DataLayer.DataAccess
{
    public class DataBaseInitializer
    {
        public Student[] InitStudents()
        {
            var students = new Student[]
            {
                new Student {StudentId = 1, Name = "Vladislav", Surname = "Kruzhkov"},
                new Student {StudentId = 2, Name = "Ferre", Surname = "Dezutter"},
                new Student {StudentId = 3, Name = "Ivan", Surname = "Ivanov"},
                new Student {StudentId = 4, Name = "Petr", Surname = "Petrov"},
                new Student {StudentId = 5, Name = "Anton", Surname = "Antonov"}
            };
            return students;
        }

        public Professor[] InitProfessors()
        {
            var professors = new Professor[]
            {
                new Professor { ProfessorId = 1, Name = "Victor", Surname = "Vtorov"},
                new Professor { ProfessorId = 2, Name = "Anastasiia", Surname = "Stotskaya"},
                new Professor { ProfessorId = 3, Name = "Eduard", Surname = "Chernishov" }
            };
            return professors;
        }

        public Subject[] InitSubjects()
        {
            var subjects = new Subject[]
            {
                new Subject { SubjectId = 1, ProfessorId = 1, Name = "Control Systems"},
                new Subject { SubjectId = 4, ProfessorId = 1, Name = "Adaptive And Nonlinear Systems" },
                new Subject { SubjectId = 2, ProfessorId = 2, Name = "LabView" },
                new Subject { SubjectId = 3, ProfessorId = 3, Name = "Electrical Engineering" }
            };
            return subjects;
        }

        public Attendance[] InitAttendance()
        {
            var attendance = new Attendance[]
            {
                new Attendance {AttendanceId = 1, SubjectId = 1, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 2, SubjectId = 1, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 3, SubjectId = 1, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 4, SubjectId = 1, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 5, SubjectId = 1, StudentId = 1, IsStudentOnLecture = true, Mark = 5},

                new Attendance {AttendanceId = 6, SubjectId = 2, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 7, SubjectId = 2, StudentId = 1, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 8, SubjectId = 2, StudentId = 1, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 9, SubjectId = 2, StudentId = 1, IsStudentOnLecture = true, Mark = 2},
                new Attendance {AttendanceId = 10, SubjectId = 2, StudentId = 1, IsStudentOnLecture = true, Mark = 1},

                new Attendance {AttendanceId = 11, SubjectId = 3, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 12, SubjectId = 3, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 13, SubjectId = 3, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 14, SubjectId = 3, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 15, SubjectId = 3, StudentId = 1, IsStudentOnLecture = false, Mark = 0},

                new Attendance {AttendanceId = 16, SubjectId = 4, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 17, SubjectId = 4, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 18, SubjectId = 4, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 19, SubjectId = 4, StudentId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 20, SubjectId = 4, StudentId = 1, IsStudentOnLecture = true, Mark = 5},
                
                new Attendance {AttendanceId = 21, SubjectId = 1, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 22, SubjectId = 1, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 23, SubjectId = 1, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 24, SubjectId = 1, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 25, SubjectId = 1, StudentId = 2, IsStudentOnLecture = true, Mark = 4},

                new Attendance {AttendanceId = 26, SubjectId = 2, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 27, SubjectId = 2, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 28, SubjectId = 2, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 29, SubjectId = 2, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 30, SubjectId = 2, StudentId = 2, IsStudentOnLecture = true, Mark = 4},

                new Attendance {AttendanceId = 31, SubjectId = 3, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 32, SubjectId = 3, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 33, SubjectId = 3, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 34, SubjectId = 3, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 35, SubjectId = 3, StudentId = 2, IsStudentOnLecture = false, Mark = 4},

                new Attendance {AttendanceId = 36, SubjectId = 4, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 37, SubjectId = 4, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 38, SubjectId = 4, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 39, SubjectId = 4, StudentId = 2, IsStudentOnLecture = false, Mark = 4},
                new Attendance {AttendanceId = 40, SubjectId = 4, StudentId = 2, IsStudentOnLecture = true, Mark = 4},
                
                new Attendance {AttendanceId = 41, SubjectId = 1, StudentId = 3, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 42, SubjectId = 1, StudentId = 3, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 43, SubjectId = 1, StudentId = 3, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 44, SubjectId = 1, StudentId = 3, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 45, SubjectId = 1, StudentId = 3, IsStudentOnLecture = true, Mark = 5},

                new Attendance {AttendanceId = 46, SubjectId = 2, StudentId = 3, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 47, SubjectId = 2, StudentId = 3, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 48, SubjectId = 2, StudentId = 3, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 49, SubjectId = 2, StudentId = 3, IsStudentOnLecture = true, Mark = 2},
                new Attendance {AttendanceId = 50, SubjectId = 2, StudentId = 3, IsStudentOnLecture = true, Mark = 1},

                new Attendance {AttendanceId = 51, SubjectId = 3, StudentId = 3, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 52, SubjectId = 3, StudentId = 3, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 53, SubjectId = 3, StudentId = 3, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 54, SubjectId = 3, StudentId = 3, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 55, SubjectId = 3, StudentId = 3, IsStudentOnLecture = false, Mark = 0},

                new Attendance {AttendanceId = 56, SubjectId = 4, StudentId = 3, IsStudentOnLecture = true, Mark = 0},
                new Attendance {AttendanceId = 57, SubjectId = 4, StudentId = 3, IsStudentOnLecture = true, Mark = 0},
                new Attendance {AttendanceId = 58, SubjectId = 4, StudentId = 3, IsStudentOnLecture = true, Mark = 0},
                new Attendance {AttendanceId = 59, SubjectId = 4, StudentId = 3, IsStudentOnLecture = true, Mark = 0},
                new Attendance {AttendanceId = 60, SubjectId = 4, StudentId = 3, IsStudentOnLecture = true, Mark = 0},
                
                new Attendance {AttendanceId = 61, SubjectId = 1, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 62, SubjectId = 1, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 63, SubjectId = 1, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 64, SubjectId = 1, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 65, SubjectId = 1, StudentId = 4, IsStudentOnLecture = true, Mark = 5},

                new Attendance {AttendanceId = 66, SubjectId = 2, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 67, SubjectId = 2, StudentId = 4, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 68, SubjectId = 2, StudentId = 4, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 69, SubjectId = 2, StudentId = 4, IsStudentOnLecture = true, Mark = 2},
                new Attendance {AttendanceId = 70, SubjectId = 2, StudentId = 4, IsStudentOnLecture = true, Mark = 1},

                new Attendance {AttendanceId = 71, SubjectId = 3, StudentId = 4, IsStudentOnLecture = true, Mark = 1},
                new Attendance {AttendanceId = 72, SubjectId = 3, StudentId = 4, IsStudentOnLecture = true, Mark = 2},
                new Attendance {AttendanceId = 73, SubjectId = 3, StudentId = 4, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 74, SubjectId = 3, StudentId = 4, IsStudentOnLecture = true, Mark = 4},
                new Attendance {AttendanceId = 75, SubjectId = 3, StudentId = 4, IsStudentOnLecture = true, Mark = 5},

                new Attendance {AttendanceId = 76, SubjectId = 4, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 77, SubjectId = 4, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 78, SubjectId = 4, StudentId = 4, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 79, SubjectId = 4, StudentId = 4, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 80, SubjectId = 4, StudentId = 4, IsStudentOnLecture = true, Mark = 5},
                
                new Attendance {AttendanceId = 81, SubjectId = 1, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 82, SubjectId = 1, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 83, SubjectId = 1, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 84, SubjectId = 1, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 85, SubjectId = 1, StudentId = 5, IsStudentOnLecture = false, Mark = 0},

                new Attendance {AttendanceId = 86, SubjectId = 2, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 87, SubjectId = 2, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 88, SubjectId = 2, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 89, SubjectId = 2, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 90, SubjectId = 2, StudentId = 5, IsStudentOnLecture = false, Mark = 0},

                new Attendance {AttendanceId = 91, SubjectId = 3, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 92, SubjectId = 3, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 93, SubjectId = 3, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 94, SubjectId = 3, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 95, SubjectId = 3, StudentId = 5, IsStudentOnLecture = false, Mark = 0},

                new Attendance {AttendanceId = 96, SubjectId = 4, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 97, SubjectId = 4, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 98, SubjectId = 4, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 99, SubjectId = 4, StudentId = 5, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 100, SubjectId = 4, StudentId = 5, IsStudentOnLecture = false, Mark = 0}
            };
            return attendance;
        }
    }
}
