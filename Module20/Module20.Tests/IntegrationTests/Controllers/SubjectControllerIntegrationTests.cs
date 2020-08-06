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
    public class SubjectControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public SubjectControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetSubjects()
        {
            var httpResponse = await _client.GetAsync("/Subjects");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var subjects = JsonConvert.DeserializeObject<IEnumerable<Subject>>(stringResponse);
            Assert.Contains(subjects, s => s.SubjectId == 1);
            Assert.Contains(subjects, s => s.SubjectId == 2);
            Assert.Contains(subjects, s => s.SubjectId == 4);
        }

        [Fact]
        public async Task CanGetSubjectById()
        {
            var httpResponse = await _client.GetAsync("/Subjects/1");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var subject = JsonConvert.DeserializeObject<Subject>(stringResponse);
            Assert.Equal(1, subject.SubjectId);
            Assert.Equal("Control Systems", subject.Name);
            Assert.Equal(1, subject.ProfessorId);
        }

        [Fact]
        public async Task CanCreateSubject()
        {
            var studentToAdd = new Subject { Name = "TestSubject", ProfessorId = 3 };

            var contents = new StringContent(JsonConvert.SerializeObject(studentToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync("/Subjects", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var addedStudent = JsonConvert.DeserializeObject<Subject>(stringResponse);

            Assert.Equal("TestSubject", addedStudent.Name);
            Assert.Equal(3, addedStudent.ProfessorId);
        }

        [Fact]
        public async Task CanUpdateSubject()
        {
            var studentToAdd = new Subject { Name = "TestSubjectChanged", ProfessorId = 3, SubjectId = 2 };

            var contents = new StringContent(JsonConvert.SerializeObject(studentToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync("/Subjects", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var updatedSubject = JsonConvert.DeserializeObject<Subject>(stringResponse);

            Assert.Equal("TestSubjectChanged", updatedSubject.Name);
            Assert.Equal(3, updatedSubject.ProfessorId);
            Assert.Equal(2, updatedSubject.SubjectId);
        }

        [Fact]
        public async Task CanDeleteSubject()
        {
            var httpResponse = await _client.DeleteAsync($"/Subjects/3");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var deletedSubject = JsonConvert.DeserializeObject<Subject>(stringResponse);

            Assert.Null(deletedSubject);
            Assert.Null(deletedSubject);
        }
    }
}
