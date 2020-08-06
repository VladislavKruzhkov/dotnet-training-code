using System;
using BusinessLogic.DTO;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.MapperConfiguration;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Moq;
using Xunit;

namespace Module20.Tests.ServiceTests
{
    public class AttendanceServiceTests
    {
        private readonly Mock<IRepository<Attendance>> _mockRepository = new Mock<IRepository<Attendance>>();

        private readonly MappingConfiguration _configuration = new MappingConfiguration();

        private readonly AttendanceDTO _attendanceDto = new AttendanceDTO {IsStudentOnLecture = false, Mark = 0, StudentId = 1, SubjectId = 1};

        [Fact]
        public void Create_CreatesAttendance()
        {
            var mapper = _configuration.ConfigureMapper();

            var serviceAccessorMock = new Mock<Func<AcademicPerformanceType, IAcademicPerformanceCheckerService>>();

            var academicPerformanceCheckerMock = new Mock<IAcademicPerformanceCheckerService>();

            serviceAccessorMock.Setup(_=>_.Invoke(It.IsAny<AcademicPerformanceType>())).Returns(academicPerformanceCheckerMock.Object);

            var service = new AttendanceService(_mockRepository.Object, mapper, serviceAccessorMock.Object);

            service.Create(_attendanceDto);

            _mockRepository.Verify(repository => repository.Create(It.IsAny<Attendance>()), Times.Once);

            serviceAccessorMock.Verify(accessor =>
                accessor(AcademicPerformanceType.Attendance).CheckStudentAcademicPerformance(_attendanceDto.StudentId, _attendanceDto.SubjectId), Times.Exactly(2));
        }
    }
}
