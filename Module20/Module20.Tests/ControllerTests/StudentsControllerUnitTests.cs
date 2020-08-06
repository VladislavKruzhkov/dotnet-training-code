using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WebApplication.Controllers;
using Xunit;

namespace Module20.Tests.ControllerTests
{
    public class StudentsControllerUnitTests
    {
        private readonly List<StudentDTO> _testListStudentDto = new List<StudentDTO>
        {
            new StudentDTO { StudentId = 1, Name = "Tom", Surname = "Black"},
            new StudentDTO { StudentId = 2, Name = "Alice", Surname = "InImagineLand"},
            new StudentDTO { StudentId = 3, Name = "Sam", Surname = "Williams"},
            new StudentDTO { StudentId = 4, Name = "Kate", Surname = "White"}
        };

        private readonly StudentDTO _testStudentDtoToPost = new StudentDTO { Name = "Ivan", Surname = "Petrov" };

        private readonly StudentDTO _testStudentDtoToPut = new StudentDTO { StudentId = 1, Name = "Ivan", Surname = "Petrov" };

        private readonly Mock<IStudentService> _mockService = new Mock<IStudentService>();

        [Fact]
        public void GetAll_ReturnsListOfStudents()
        {
            _mockService.Setup(service => service.GetAll()).Returns(_testListStudentDto);
            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var resultStudentList = controller.GetAll().ToList();

            for (var item = 0; item < resultStudentList.Count; item++)
            {
                Assert.Equal(resultStudentList[item].StudentId, _testListStudentDto[item].StudentId);
                Assert.Equal(resultStudentList[item].Name, _testListStudentDto[item].Name);
                Assert.Equal(resultStudentList[item].Surname, _testListStudentDto[item].Surname);
            }
        }

        [Fact]
        public void GetById_ReturnsActionNotFoundResult()
        {
            var testStudentId = 5;
            _mockService.Setup(service =>
                service.GetById(testStudentId)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == testStudentId));
            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.GetById(testStudentId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_ReturnsActionOkObjectResult()
        {
            var testStudentId = 1;

            _mockService.Setup(service => 
                service.GetById(testStudentId)).Returns(_testListStudentDto.FirstOrDefault(s => 
                s.StudentId == testStudentId));
            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var resultStudent = controller.GetById(1);

            var viewResult = Assert.IsType<OkObjectResult>(resultStudent);
            var model = Assert.IsType<StudentDTO>(viewResult.Value);
            Assert.Equal(1, model.StudentId);
            Assert.Equal("Tom", model.Name);
            Assert.Equal("Black", model.Surname);
        }

        [Fact]
        public void Post_ReturnsActionBadRequestResult()
        {
            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Post(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Post_ReturnsActionOkObjectResult()
        {
            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Post(_testStudentDtoToPost);

            Assert.IsType<OkObjectResult>(result);
            _mockService.Verify(service => service.Create(_testStudentDtoToPost), Times.Once);
        }

        [Fact]
        public void Put_ReturnsActionBadRequestResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testStudentDtoToPut.StudentId)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == _testStudentDtoToPut.StudentId));

            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Put(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Put_ReturnsActionNotFoundResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testStudentDtoToPut.StudentId)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == _testStudentDtoToPut.StudentId));

            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            _testStudentDtoToPut.StudentId = 10;

            var result = controller.Put(_testStudentDtoToPut);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ReturnsActionOkObjectResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testStudentDtoToPut.StudentId)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == _testStudentDtoToPut.StudentId));

            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Put(_testStudentDtoToPut);

            Assert.IsType<OkObjectResult>(result);
            _mockService.Verify(service => service.Update(_testStudentDtoToPut), Times.Once);
        }

        [Fact]
        public void Delete_ReturnsActionNotFoundResult()
        {
            var wrongStudentIdToDelete = 10;

            _mockService.Setup(service =>
                service.GetById(wrongStudentIdToDelete)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == wrongStudentIdToDelete));

            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Delete(wrongStudentIdToDelete);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsActionOkResult()
        {
            var studentIdToDelete = 1;

            _mockService.Setup(service =>
                service.GetById(studentIdToDelete)).Returns(_testListStudentDto.FirstOrDefault(s =>
                s.StudentId == studentIdToDelete));

            var controller = new StudentsController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Delete(studentIdToDelete);

            Assert.IsType<OkResult>(result);
            _mockService.Verify(service => service.Delete(1));
        }
    }
}
