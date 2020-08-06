using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BusinessLogic.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Student> _studentRepo;

        private readonly IRepository<Subject> _subjectRepo;

        private readonly ILogger _logger;

        public ReportService(IRepository<Student> studentRepo, IRepository<Subject> subjectRepo, ILoggerFactory loggerFactory)
        {
            _studentRepo = studentRepo;
            _subjectRepo = subjectRepo;
            _logger = loggerFactory.CreateLogger<ReportService>();
        }

        public string CreateReportByStudent(string studentName, string studentSurname, int reportType)
        {
            var students = _studentRepo.Find(s => s.Name == studentName && s.Surname == studentSurname).ToList();

            if (students.Count == 0)
            {
                _logger.LogError("Student not found");
                return null;
            }
            return ChooseFileType(students, reportType, typeof(List<Student>));
        }

        public string CreateReportBySubject(string subjectName, int reportType)
        {
            var subject = _subjectRepo.Find(s => s.Name == subjectName).FirstOrDefault();

            if (subject == null)
            {
                _logger.LogError("Subject not found");
                return null;
            }
            
            return ChooseFileType(subject, reportType, typeof(Subject));
        }

        private string ChooseFileType(object obj, int reportType, Type type)
        {
            switch (reportType)
            {
                case 1:
                    return CreateJson(obj);
                case 2:
                    return CreateXml(obj, type);
                default:
                    throw new CustomException(ErrorCode.NotSupportedReportType, "Not supported report type");
            }
        }

        private string CreateJson(object objects)
        {
            var jsonReport = JsonConvert.SerializeObject(objects, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return jsonReport;
        }

        private string CreateXml(object objects, Type type)
        {
            var objectsToType = Convert.ChangeType(objects, type);

            var xmlSer = new XmlSerializer(type);

            var writer = new StringWriter();
            xmlSer.Serialize(writer, objectsToType);
            return writer.ToString();
        }
    }
}
