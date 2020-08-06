using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataLayer.Entities;
using Newtonsoft.Json;
using WebApplication;
using Xunit;

namespace Module20.Tests.IntegrationTests.Controllers
{
    public class ReportControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ReportControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanCreateTxtReportByStudent()
        {
            var studentName = "Vladislav";
            var studentSurname = "Kruzhkov";
            var reportType = 1;

            var httpResponse = await _client.GetAsync($"/Report/Students?studentName={studentName}&studentSurname={studentSurname}&reportType={reportType}");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResponse);
            
            Assert.Contains(student, s => s.StudentId == 1 && s.Name == studentName && s.Surname == studentSurname);

            var studentAttendance = student.FirstOrDefault().Attendance;

            for (var attendanceNumber = 1; attendanceNumber <= 20; attendanceNumber++)
            {
                Assert.Contains(studentAttendance, a => a.AttendanceId == attendanceNumber);
            }
        }

        [Fact]
        public async Task CanCreateTxtReportBySubject()
        {
            var subjectName = "Control Systems";
            var reportType = 1;

            var httpResponse = await _client.GetAsync($"/Report/Subject?subjectName={subjectName}&reportType={reportType}");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var subject = JsonConvert.DeserializeObject<Subject>(stringResponse);

            Assert.True(subject.SubjectId == 1 && subject.Name == "Control Systems");

            var studentAttendance = subject.Attendance;

            for (var attendanceNumber = 1; attendanceNumber <= 5; attendanceNumber++)
            {
                Assert.Contains(studentAttendance, a => a.AttendanceId == attendanceNumber);
            }
        }
    }
}
