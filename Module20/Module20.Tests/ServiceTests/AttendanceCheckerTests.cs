using System;
using System.Collections.Generic;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using BusinessLogic.Services.AcademicPerformanceCheckerServices;
using BusinessLogic.Services.Options;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Module20.Tests.ServiceTests
{
    public class AttendanceCheckerTests
    {
        private readonly Mock<IRepository<Attendance>> _mockAttendanceRepository = new Mock<IRepository<Attendance>>();

        private readonly Mock<IRepository<Student>> _mockStudentRepository = new Mock<IRepository<Student>>();

        private readonly Mock<IRepository<Subject>> _mockSubjectRepository = new Mock<IRepository<Subject>>();

        private readonly Mock<IRepository<Professor>> _mockProfessorRepository = new Mock<IRepository<Professor>>();

        private readonly Mock<IOptions<AcademicPerformanceOptions>> _options = new Mock<IOptions<AcademicPerformanceOptions>>();

        private readonly Mock<Func<NotificationType, INotifierService>> _notifierServiceAccessorMock = new Mock<Func<NotificationType, INotifierService>>();

        private readonly Mock<INotifierService> _notifierMock = new Mock<INotifierService>();

        private readonly Subject _subject = new Subject
        {
            SubjectId = 1,
            Name = "SubjectName",
            ProfessorId = 1
        };

        private readonly Professor _professor = new Professor
        {
            ProfessorId = 1,
            Name = "ProfessorName",
            Surname = "ProfessorSurname"
        };

        private readonly Student _studentTriggersEmail = new Student
        {
            Name = "Trigger",
            Surname = "Student",
            StudentId = 1,
            Attendance = new List<Attendance>
            {
                new Attendance {AttendanceId = 1, StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 2, StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 3, StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 0},
                new Attendance {AttendanceId = 4, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 3}
            }
        };

        private readonly Student _studentNotTriggersEmail = new Student
        {
            Name = "NotTrigger",
            Surname = "Student",
            StudentId = 2,
            Attendance = new List<Attendance>
            {
                new Attendance {AttendanceId = 1, StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 5},
                new Attendance {AttendanceId = 2, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 3, StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 5},
                new Attendance {AttendanceId = 4, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5}
            }
        };

        [Fact]
        public void AttendanceChecker_SendsEmail()
        {
            var studentId = _studentTriggersEmail.StudentId;
            const int subjectId = 1;

            _notifierServiceAccessorMock.Setup(_ => _.Invoke(It.IsAny<NotificationType>())).Returns(_notifierMock.Object);

            _options.Setup(o => o.Value).Returns(new AcademicPerformanceOptions{ MaxMissedLectures = 2 });

            _mockAttendanceRepository.Setup(repo =>
                    repo.Find(It.IsAny<Func<Attendance, bool>>()))
                .Returns(_studentTriggersEmail.Attendance);

            _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(_studentTriggersEmail);

            _mockSubjectRepository.Setup(repo => repo.Get(subjectId)).Returns(_subject);

            _mockProfessorRepository.Setup(repo => repo.Get(_subject.ProfessorId)).Returns(_professor);

            var attendanceChecker = new AttendanceChecker(_mockAttendanceRepository.Object,
                _mockSubjectRepository.Object,
                _mockStudentRepository.Object,
                _mockProfessorRepository.Object,
                new NullLoggerFactory(),
                _notifierServiceAccessorMock.Object,
                _options.Object);

            attendanceChecker.CheckStudentAcademicPerformance(studentId, subjectId);

            _notifierServiceAccessorMock.Verify(accessor =>
                accessor(NotificationType.EmailNotification).Notify(It.IsAny<string>()), Times.Exactly(2));
        }

        [Fact]
        public void AttendanceChecker_NotSendsEmail()
        {
            var studentId = _studentNotTriggersEmail.StudentId;
            const int subjectId = 1;

            _notifierServiceAccessorMock.Setup(_ => _.Invoke(It.IsAny<NotificationType>())).Returns(_notifierMock.Object);

            _options.Setup(o => o.Value).Returns(new AcademicPerformanceOptions { MaxMissedLectures = 3 });

            _mockAttendanceRepository.Setup(repo =>
                    repo.Find(It.IsAny<Func<Attendance, bool>>()))
                .Returns(_studentNotTriggersEmail.Attendance);

            _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(_studentNotTriggersEmail);

            _mockSubjectRepository.Setup(repo => repo.Get(subjectId)).Returns(_subject);

            _mockProfessorRepository.Setup(repo => repo.Get(_subject.ProfessorId)).Returns(_professor);

            var attendanceChecker = new AttendanceChecker(_mockAttendanceRepository.Object,
                _mockSubjectRepository.Object,
                _mockStudentRepository.Object,
                _mockProfessorRepository.Object,
                new NullLoggerFactory(),
                _notifierServiceAccessorMock.Object,
                _options.Object);

            attendanceChecker.CheckStudentAcademicPerformance(studentId, subjectId);

            _notifierServiceAccessorMock.Verify(accessor =>
                accessor(NotificationType.EmailNotification).Notify(It.IsAny<string>()), Times.Exactly(0));
        }
    }
}
