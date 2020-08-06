using System;
using System.Linq;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using BusinessLogic.Services.Options;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BusinessLogic.Services.AcademicPerformanceCheckerServices
{
    public class AverageMarkChecker : IAcademicPerformanceCheckerService
    {
        private readonly IRepository<Attendance> _attendanceRepo;

        private readonly IRepository<Student> _studentRepo;

        private readonly IRepository<Subject> _subjectRepo;

        private readonly ILogger _logger;

        private readonly Func<NotificationType, INotifierService> _notifierService;

        private readonly AcademicPerformanceOptions _options;

        public AverageMarkChecker(IRepository<Attendance> attendanceRepo, IRepository<Subject> subjectRepo, IRepository<Student> studentRepo, 
            ILoggerFactory loggerFactory, Func<NotificationType, INotifierService> notifierService, IOptions<AcademicPerformanceOptions> options)
        {
            _attendanceRepo = attendanceRepo;
            _subjectRepo = subjectRepo;
            _studentRepo = studentRepo;
            _notifierService = notifierService;
            _logger = loggerFactory.CreateLogger<AverageMarkChecker>();
            _options = options.Value;
        }

        public void CheckStudentAcademicPerformance(int studentId, int subjectId)
        {
            var student = _studentRepo.Get(studentId);

            var attendancesToCheck = _attendanceRepo.Find(a => a.StudentId == studentId && a.SubjectId == subjectId).ToList();

            if (attendancesToCheck.Sum(a => a.Mark) / attendancesToCheck.Count < _options.MinMark)
            {
                var notification = $"{student.Name} {student.Surname}, " +
                                   $"you have average mark less than {_options.MinMark} by subject {_subjectRepo.Get(subjectId).Name}";

                _logger.LogInformation($"Student with id {studentId} was notified: {notification}");

                _notifierService(NotificationType.SmsNotification).Notify($"{student.Name} {student.Surname}");
            }
        }
    }
}