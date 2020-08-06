using System;
using System.Linq;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BusinessLogic.Services.Options;


namespace BusinessLogic.Services.AcademicPerformanceCheckerServices
{
    public class AttendanceChecker : IAcademicPerformanceCheckerService
    {
        private readonly IRepository<Attendance> _attendanceRepo;

        private readonly IRepository<Student> _studentRepo;

        private readonly IRepository<Subject> _subjectRepo;

        private readonly IRepository<Professor> _professorRepo;

        private readonly ILogger _logger;

        private readonly Func<NotificationType, INotifierService> _notifierService;

        private readonly AcademicPerformanceOptions _options;

        public AttendanceChecker(IRepository<Attendance> attendanceRepo, IRepository<Subject> subjectRepo, 
            IRepository<Student> studentRepo, IRepository<Professor> professorRepo,
            ILoggerFactory loggerFactory, Func<NotificationType, INotifierService> notifierService, IOptions<AcademicPerformanceOptions> options)
        {
            _attendanceRepo = attendanceRepo;
            _subjectRepo = subjectRepo;
            _studentRepo = studentRepo;
            _professorRepo = professorRepo;
            _notifierService = notifierService;
            _logger = loggerFactory.CreateLogger<AttendanceChecker>();
            _options = options.Value;
        }

        public void CheckStudentAcademicPerformance(int studentId, int subjectId)
        {
            var attendancesToCheck = _attendanceRepo.Find(a => 
                a.StudentId == studentId && a.SubjectId == subjectId).ToList();

            var subject = _subjectRepo.Get(subjectId);

            if (attendancesToCheck.Where(a => a.IsStudentOnLecture == false).ToList().Count >= _options.MaxMissedLectures)
            {
                var student = _studentRepo.Get(studentId);

                var professor = _professorRepo.Get(subject.ProfessorId);

                var notification =
                    $"{professor.Name} {professor.Surname}, " +
                    $"{student.Name} {student.Surname} " +
                    $"missed more than {_options.MaxMissedLectures} classes by subject {subject.Name}";

                _logger.LogInformation($"Email was sent to student with id {studentId} and professor with id {subject.ProfessorId}: {notification}");

                _notifierService(NotificationType.EmailNotification).Notify($"{professor.Name} {professor.Surname}");
                _notifierService(NotificationType.EmailNotification).Notify($"{student.Name} {student.Surname}");
            }
        }
    }
}
