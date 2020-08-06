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
    public class AverageMarkCheckerTests
    {
        private readonly Mock<IRepository<Attendance>> _mockAttendanceRepository = new Mock<IRepository<Attendance>>();

        private readonly Mock<IRepository<Student>> _mockStudentRepository = new Mock<IRepository<Student>>();

        private readonly Mock<IRepository<Subject>> _mockSubjectRepository = new Mock<IRepository<Subject>>();

        private readonly Mock<IOptions<AcademicPerformanceOptions>> _options = new Mock<IOptions<AcademicPerformanceOptions>>();

        private readonly Mock<Func<NotificationType, INotifierService>> _notifierServiceAccessorMock = new Mock<Func<NotificationType, INotifierService>>();

        private readonly Mock<INotifierService> _notifierMock = new Mock<INotifierService>();

        private readonly Subject _subject = new Subject
        {
            SubjectId = 1,
            Name = "SubjectName",
            ProfessorId = 1
        };

        private readonly Student _studentTriggersSms = new Student
        {
            Name = "Trigger",
            Surname = "Student",
            StudentId = 1,
            Attendance = new List<Attendance>
            {
                new Attendance {AttendanceId = 1, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 2, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 3, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 3},
                new Attendance {AttendanceId = 4, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 3}
            }
        };

        private readonly Student _studentNotTriggersSms = new Student
        {
            Name = "NotTrigger",
            Surname = "Student",
            StudentId = 2,
            Attendance = new List<Attendance>
            {
                new Attendance {AttendanceId = 1, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 2, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 3, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5},
                new Attendance {AttendanceId = 4, StudentId = 1, SubjectId = 1, IsStudentOnLecture = true, Mark = 5}
            }
        };

        [Fact]
        public void AverageMarkChecker_SendsSms()
        {
            var studentId = _studentTriggersSms.StudentId;
            const int subjectId = 1;

            _notifierServiceAccessorMock.Setup(_ => _.Invoke(It.IsAny<NotificationType>())).Returns(_notifierMock.Object);

            _options.Setup(o => o.Value).Returns(new AcademicPerformanceOptions { MinMark = 4 });

            _mockAttendanceRepository.Setup(repo =>
                    repo.Find(It.IsAny<Func<Attendance, bool>>()))
                .Returns(_studentTriggersSms.Attendance);

            _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(_studentTriggersSms);

            _mockSubjectRepository.Setup(repo => repo.Get(subjectId)).Returns(_subject);

            var averageMarkChecker = new AverageMarkChecker(_mockAttendanceRepository.Object,
                _mockSubjectRepository.Object,
                _mockStudentRepository.Object,
                new NullLoggerFactory(),
                _notifierServiceAccessorMock.Object,
                _options.Object);

            averageMarkChecker.CheckStudentAcademicPerformance(studentId, subjectId);

            _notifierServiceAccessorMock.Verify(accessor =>
                accessor(NotificationType.SmsNotification).Notify(It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void AverageMarkChecker_NotSendsSms()
        {
            var studentId = _studentNotTriggersSms.StudentId;
            const int subjectId = 1;

            _notifierServiceAccessorMock.Setup(_ => _.Invoke(It.IsAny<NotificationType>())).Returns(_notifierMock.Object);

            _options.Setup(o => o.Value).Returns(new AcademicPerformanceOptions { MinMark = 4 });

            _mockAttendanceRepository.Setup(repo =>
                    repo.Find(It.IsAny<Func<Attendance, bool>>()))
                .Returns(_studentNotTriggersSms.Attendance);

            _mockStudentRepository.Setup(repo => repo.Get(studentId)).Returns(_studentNotTriggersSms);

            _mockSubjectRepository.Setup(repo => repo.Get(subjectId)).Returns(_subject);

            var averageMarkChecker = new AverageMarkChecker(_mockAttendanceRepository.Object,
                _mockSubjectRepository.Object,
                _mockStudentRepository.Object,
                new NullLoggerFactory(),
                _notifierServiceAccessorMock.Object,
                _options.Object);

            averageMarkChecker.CheckStudentAcademicPerformance(studentId, subjectId);

            _notifierServiceAccessorMock.Verify(accessor =>
                accessor(NotificationType.SmsNotification).Notify(It.IsAny<string>()), Times.Exactly(0));
        }
    }
}