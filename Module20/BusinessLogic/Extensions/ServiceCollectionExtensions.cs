using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.AcademicPerformanceCheckerServices;
using BusinessLogic.Services.NotifierServices;
using BusinessLogic.Services.ReportService;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBllServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ISubjectService, SubjectService>();

            services.AddScoped<IAttendanceService, AttendanceService>();

            services.AddScoped<IProfessorService, ProfessorService>();

            services.AddScoped<IReportService, ReportService>();

            services.AddTransient<SmsService>();
            services.AddTransient<EmailService>();

            services.AddTransient<Func<NotificationType, INotifierService>>(serviceProvider => key =>
            {
                return key switch
                {
                    NotificationType.SmsNotification => serviceProvider.GetService<SmsService>(),
                    NotificationType.EmailNotification => serviceProvider.GetService<EmailService>(),
                    _ => throw new KeyNotFoundException()
                };
            });

            services.AddTransient<AverageMarkChecker>();
            services.AddTransient<AttendanceChecker>();

            services.AddTransient<Func<AcademicPerformanceType, IAcademicPerformanceCheckerService>>(serviceProvider => key =>
            {
                return key switch
                {
                    AcademicPerformanceType.AverageMark => serviceProvider.GetService<AverageMarkChecker>(),
                    AcademicPerformanceType.Attendance => serviceProvider.GetService<AttendanceChecker>(),
                    _ => throw new KeyNotFoundException()
                };
            });
        }
    }

    public enum NotificationType
    {
        SmsNotification = 0,
        EmailNotification = 1
    }

    public enum AcademicPerformanceType
    {
        AverageMark = 0,
        Attendance = 1
    }
}
