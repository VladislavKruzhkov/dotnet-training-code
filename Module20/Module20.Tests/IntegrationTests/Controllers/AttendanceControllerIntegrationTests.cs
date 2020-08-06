using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Newtonsoft.Json;
using WebApplication;
using Xunit;

namespace Module20.Tests.IntegrationTests.Controllers
{
    public class AttendanceControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AttendanceControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetAttendances()
        {
            var httpResponse = await _client.GetAsync("/Attendance");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var attendances = JsonConvert.DeserializeObject<IEnumerable<Attendance>>(stringResponse);
            Assert.Contains(attendances, s => s.AttendanceId == 1);
            Assert.Contains(attendances, s => s.AttendanceId == 2);
            Assert.Contains(attendances, s => s.AttendanceId == 4);
            Assert.Contains(attendances, s => s.AttendanceId == 5);
            Assert.Contains(attendances, s => s.AttendanceId == 6);
            Assert.Contains(attendances, s => s.AttendanceId == 7);
            Assert.Contains(attendances, s => s.AttendanceId == 8);
            Assert.Contains(attendances, s => s.AttendanceId == 9);
        }

        [Fact]
        public async Task CanGetAttendanceById()
        {
            var httpResponse = await _client.GetAsync("/Attendance/1");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var attendance = JsonConvert.DeserializeObject<Attendance>(stringResponse);
            Assert.Equal(1, attendance.AttendanceId);
            Assert.Equal(1, attendance.SubjectId);
            Assert.Equal(1, attendance.StudentId);
            Assert.Equal(5, attendance.Mark);
            Assert.True(attendance.IsStudentOnLecture);
        }

        [Fact]
        public async Task CanCreateAttendance()
        {
            var attendanceToAdd = new Attendance { StudentId = 1, SubjectId = 1, IsStudentOnLecture = false, Mark = 0 };

            var contents = new StringContent(JsonConvert.SerializeObject(attendanceToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync("/Attendance", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var addedAttendance = JsonConvert.DeserializeObject<Attendance>(stringResponse);
            Assert.Equal(1, addedAttendance.SubjectId);
            Assert.Equal(1, addedAttendance.StudentId);
            Assert.Equal(0, addedAttendance.Mark);
            Assert.False(addedAttendance.IsStudentOnLecture);
        }

        [Fact]
        public async Task CanUpdateAttendance()
        {
            var attendanceToUpdate = new Attendance { AttendanceId = 2, StudentId = 3, SubjectId = 3, IsStudentOnLecture = false, Mark = 0};

            var contents = new StringContent(JsonConvert.SerializeObject(attendanceToUpdate), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync("/Attendance", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var updatedAttendance = JsonConvert.DeserializeObject<Attendance>(stringResponse);

            Assert.Equal(2, updatedAttendance.AttendanceId);
            Assert.Equal(3, updatedAttendance.SubjectId);
            Assert.Equal(3, updatedAttendance.StudentId);
            Assert.Equal(0, updatedAttendance.Mark);
            Assert.False(updatedAttendance.IsStudentOnLecture);
        }

        [Fact]
        public async Task CanDeleteAttendance()
        {
            var httpResponse = await _client.DeleteAsync($"/Attendance/3");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var deletedAttendance = JsonConvert.DeserializeObject<Attendance>(stringResponse);

            Assert.Null(deletedAttendance);
            Assert.Null(deletedAttendance);
        }
    }
}
