using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Newtonsoft.Json;
using WebApplication;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Module20.Tests.IntegrationTests.Controllers
{
    public class ProfessorControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProfessorControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetProfessors()
        {
            var httpResponse = await _client.GetAsync("/Professors");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var professors = JsonConvert.DeserializeObject<IEnumerable<Professor>>(stringResponse);
            Assert.Contains(professors, s => s.ProfessorId == 1);
            Assert.Contains(professors, s => s.ProfessorId == 2);
        }

        [Fact]
        public async Task CanGetProfessorById()
        {
            var httpResponse = await _client.GetAsync("/Professors/1");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var professor = JsonConvert.DeserializeObject<Professor>(stringResponse);
            Assert.Equal(1, professor.ProfessorId);
            Assert.Equal("Victor", professor.Name);
        }

        [Fact]
        public async Task CanCreateProfessor()
        {
            var professorToAdd = new Professor { Name = "TestProfessor", Surname = "One" };

            var contents = new StringContent(JsonConvert.SerializeObject(professorToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PostAsync("/Professors", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var addedProfessor = JsonConvert.DeserializeObject<Professor>(stringResponse);

            Assert.Equal("TestProfessor", addedProfessor.Name);
            Assert.Equal("One", addedProfessor.Surname);
        }

        [Fact]
        public async Task CanUpdateProfessor()
        {
            var professorToAdd = new Professor { Name = "TestProfessor", Surname = "ChangedSurname", ProfessorId = 2 };

            var contents = new StringContent(JsonConvert.SerializeObject(professorToAdd), Encoding.UTF8, "application/json");

            var httpResponse = await _client.PutAsync("/Professors", contents);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var updatedProfessor = JsonConvert.DeserializeObject<Professor>(stringResponse);

            Assert.Equal("TestProfessor", updatedProfessor.Name);
            Assert.Equal("ChangedSurname", updatedProfessor.Surname);
        }

        [Fact]
        public async Task CanDeleteProfessor()
        {
            var httpResponse = await _client.DeleteAsync($"/Professors/3");

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            var deletedProfessor = JsonConvert.DeserializeObject<Professor>(stringResponse);

            Assert.Null(deletedProfessor);
            Assert.Null(deletedProfessor);
        }
    }
}
