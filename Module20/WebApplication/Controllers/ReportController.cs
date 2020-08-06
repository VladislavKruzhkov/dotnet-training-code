using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        private readonly ILogger _logger;

        public ReportController(IReportService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<ReportController>();
        }

        [HttpGet("Students")]
        public IActionResult CreateReportByStudent(string studentName, string studentSurname, int reportType)
        {
            var students = _service.CreateReportByStudent(studentName, studentSurname, reportType);
            if (students == null)
            {
                _logger.LogInformation($"The student {studentName} {studentSurname} was not found");
                return NotFound();
            }
            _logger.LogInformation($"The report by student {studentName} {studentSurname} returned to user");
            return Ok(students);
        }

        [HttpGet("Subject")]
        public IActionResult CreateReportBySubject(string subjectName, int reportType)
        {
            var subject = _service.CreateReportBySubject(subjectName, reportType);
            if (subject == null)
            {
                _logger.LogInformation($"The subject {subjectName} was not found");
                return NotFound();
            }
            _logger.LogInformation($"The report by subject {subjectName} returned to user");
            return Ok(subject);
        }
    }
}
