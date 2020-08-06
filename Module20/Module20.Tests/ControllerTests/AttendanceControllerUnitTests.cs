using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WebApplication.Controllers;
using Xunit;

namespace Module20.Tests.ControllerTests
{
    public class AttendanceControllerUnitTests
    {
        private readonly List<AttendanceDTO> _testListAttendanceDto = new List<AttendanceDTO>
        {
            new AttendanceDTO { AttendanceId = 1, StudentId = 1, SubjectId = 11, IsStudentOnLecture = true, Mark = 5},
            new AttendanceDTO { AttendanceId = 2, StudentId = 2, SubjectId = 12, IsStudentOnLecture = false, Mark = 0},
            new AttendanceDTO { AttendanceId = 3, StudentId = 3, SubjectId = 13, IsStudentOnLecture = true, Mark = 0},
            new AttendanceDTO { AttendanceId = 4, StudentId = 4, SubjectId = 14, IsStudentOnLecture = true, Mark = 4}
        };

        private readonly AttendanceDTO _testAttendanceDtoToPost = new AttendanceDTO { StudentId = 1, SubjectId = 11, IsStudentOnLecture = true, Mark = 0 };

        private readonly AttendanceDTO _testAttendanceDtoToPut = new AttendanceDTO { AttendanceId = 1, StudentId = 1, SubjectId = 11, IsStudentOnLecture = true, Mark = 5 };

        private readonly AttendanceDTO _testIncorrectAttendanceDto = new AttendanceDTO { AttendanceId = 1, StudentId = 1, SubjectId = 11, IsStudentOnLecture = false, Mark = 5 };

        private readonly Mock<IAttendanceService> _mockService = new Mock<IAttendanceService>();

        [Fact]
        public void GetAll_ReturnsListOfStudents()
        {
            _mockService.Setup(service => service.GetAll()).Returns(_testListAttendanceDto);
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var resultAttendanceList = controller.GetAll().ToList();

            for (var item = 0; item < resultAttendanceList.Count; item++)
            {
                Assert.Equal(resultAttendanceList[item].AttendanceId, _testListAttendanceDto[item].AttendanceId);
                Assert.Equal(resultAttendanceList[item].StudentId, _testListAttendanceDto[item].StudentId);
                Assert.Equal(resultAttendanceList[item].SubjectId, _testListAttendanceDto[item].SubjectId);
                Assert.Equal(resultAttendanceList[item].IsStudentOnLecture, _testListAttendanceDto[item].IsStudentOnLecture);
                Assert.Equal(resultAttendanceList[item].Mark, _testListAttendanceDto[item].Mark);
            }
        }

        [Fact]
        public void GetById_ReturnsActionNotFoundResult()
        {
            var testAttendanceId = 5;

            _mockService.Setup(service =>
                service.GetById(testAttendanceId)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.AttendanceId == testAttendanceId));
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.GetById(testAttendanceId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_ReturnsActionOkObjectResult()
        {
            var testAttendanceId = 1;

            _mockService.Setup(service =>
                service.GetById(testAttendanceId)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.StudentId == testAttendanceId));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var resultAttendance = controller.GetById(testAttendanceId);

            var viewResult = Assert.IsType<OkObjectResult>(resultAttendance);
            var model = Assert.IsType<AttendanceDTO>(viewResult.Value);
            Assert.Equal(1, model.StudentId);
            Assert.Equal(1, model.AttendanceId);
            Assert.Equal(11, model.SubjectId);
            Assert.True(model.IsStudentOnLecture);
            Assert.Equal(5, model.Mark);
        }

        [Fact]
        public void Post_ReturnsActionBadRequestResult()
        {
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Post(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Post_ThrowsDummyException()
        {
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            Assert.Throws<CustomException>(() => controller.Post(_testIncorrectAttendanceDto));
        }

        [Fact]
        public void Post_ReturnsActionOkObjectResult()
        {
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Post(_testAttendanceDtoToPost);

            Assert.IsType<OkObjectResult>(result);
            _mockService.Verify(service => service.Create(_testAttendanceDtoToPost), Times.Once);
        }

        [Fact]
        public void Put_ReturnsActionBadRequestResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testAttendanceDtoToPut.AttendanceId)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.AttendanceId == _testAttendanceDtoToPut.AttendanceId));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Put(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Put_ThrowsDummyException()
        {
            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            Assert.Throws<CustomException>(() => controller.Put(_testIncorrectAttendanceDto));
        }

        [Fact]
        public void Put_ReturnsActionNotFoundResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testAttendanceDtoToPut.StudentId)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.StudentId == _testAttendanceDtoToPut.StudentId));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            _testAttendanceDtoToPut.AttendanceId = 10;

            var result = controller.Put(_testAttendanceDtoToPut);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ReturnsActionOkObjectResult()
        {
            _mockService.Setup(service =>
                service.GetById(_testAttendanceDtoToPut.StudentId)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.StudentId == _testAttendanceDtoToPut.StudentId));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Put(_testAttendanceDtoToPut);

            Assert.IsType<OkObjectResult>(result);
            _mockService.Verify(service => service.Update(_testAttendanceDtoToPut), Times.Once);
        }

        [Fact]
        public void Delete_ReturnsActionNotFoundResult()
        {
            var wrongAttendanceIdToDelete = 10;

            _mockService.Setup(service =>
                service.GetById(wrongAttendanceIdToDelete)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.AttendanceId == wrongAttendanceIdToDelete));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Delete(wrongAttendanceIdToDelete);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsActionOkResult()
        {
            var attendanceIdToDelete = 1;

            _mockService.Setup(service =>
                service.GetById(attendanceIdToDelete)).Returns(_testListAttendanceDto.FirstOrDefault(s =>
                s.AttendanceId == attendanceIdToDelete));

            var controller = new AttendanceController(_mockService.Object, new NullLoggerFactory());

            var result = controller.Delete(attendanceIdToDelete);

            Assert.IsType<OkResult>(result);
            _mockService.Verify(service => service.Delete(1), Times.Once);
        }
    }
}
