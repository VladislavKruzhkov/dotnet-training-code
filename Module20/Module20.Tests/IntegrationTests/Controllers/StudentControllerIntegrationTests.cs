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
    public class StudentControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public StudentControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetStudents()
        {
            var httpResponse = await _client.GetAsync("/Students");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResponse);
            Assert.Contains(students, s => s.StudentId == 1);
            Assert.Contains(students, s => s.StudentId == 2);
            Assert.Contains(students, s => s.StudentId == 4);
            Assert.Contains(students, s => s.StudentId == 5);
        }

        [Fact]
        public async Task CanGetStudentById()
        {
            var httpResponse = await _client.GetAsync("/Students/1");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<Student>(stringResponse);
            Assert.Equal(1, student.StudentId);
            Assert.Equal("Vladislav", student.Name);
        }

        [Fact]
        public async Task CanCreateStudent()
        {
            var studentToAdd = new Student { Name = "TestStudent", Surname = "One" };

            var contents = new StringContent(JsonConvert.SerializeObject(studentToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync("/Students", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var addedStudent = JsonConvert.DeserializeObject<Student>(stringResponse);

            Assert.Equal("TestStudent", addedStudent.Name);
            Assert.Equal("One", addedStudent.Surname);
        }

        [Fact]
        public async Task CanUpdateStudent()
        {
            var studentToAdd = new Student { Name = "TestStudent", Surname = "ChangedSurname", StudentId = 2 };

            var contents = new StringContent(JsonConvert.SerializeObject(studentToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync("/Students", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var updatedStudent = JsonConvert.DeserializeObject<Student>(stringResponse);

            Assert.Equal("TestStudent", updatedStudent.Name);
            Assert.Equal("ChangedSurname", updatedStudent.Surname);
        }

        [Fact]
        public async Task CanDeleteStudent()
        {
            var httpResponse = await _client.DeleteAsync($"/Students/3");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var deletedStudent = JsonConvert.DeserializeObject<Student>(stringResponse);

            Assert.Null(deletedStudent);
            Assert.Null(deletedStudent);
        }
    }
}
