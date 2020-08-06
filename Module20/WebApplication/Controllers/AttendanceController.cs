using System.Collections.Generic;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        private readonly ILogger _logger;

        public AttendanceController(IAttendanceService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<AttendanceController>();
        }

        [HttpGet]
        public IEnumerable<AttendanceDTO> GetAll()
        {
            _logger.LogInformation("Attendance list requested by user");
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var attendance = _service.GetById(id);
            if (attendance == null)
            {
                _logger.LogInformation($"Attendance with id {id} was not found");
                return NotFound();
            }
            _logger.LogInformation($"Attendance with id {id} returned to user");
            return Ok(attendance);
        }

        [HttpPost]
        public IActionResult Post(AttendanceDTO attendance)
        {
            if (attendance == null)
            {
                _logger.LogInformation("Bad request");
                return BadRequest();
            }
            if (attendance.IsStudentOnLecture == false && attendance.Mark != 0)
            {
                _logger.LogError("Attendance with mark but without student on lecture can't be created");
                throw new CustomException(ErrorCode.WrongMarkAndIsStudentOnLectureCondition, "Not supported condition");
            }
            _service.Create(attendance);
            _logger.LogInformation("The attendance was created");
            return Ok(attendance);
        }

        [HttpPut]
        public IActionResult Put(AttendanceDTO attendance)
        {
            if (attendance == null)
            {
                return BadRequest();
            }
            if (attendance.IsStudentOnLecture == false && attendance.Mark != 0)
            {
                _logger.LogInformation("Attendance with mark but without student on lecture can't be updated");
                throw new CustomException(ErrorCode.WrongMarkAndIsStudentOnLectureCondition, "Not supported condition");
            }
            if (_service.GetById(attendance.AttendanceId) == null)
            {
                _logger.LogInformation("The attendance is null and can't be updated");
                return NotFound();
            }
            _service.Update(attendance);
            _logger.LogInformation($"The attendance with id {attendance.AttendanceId} was updated");
            return Ok(attendance);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var attendance = _service.GetById(id);
            if (attendance == null)
            {
                _logger.LogInformation($"The attendance with id {id} is null and can't be deleted");
                return NotFound();
            }
            _service.Delete(id);
            _logger.LogInformation($"The attendance with id {id} was deleted");
            return Ok();
        }
    }
}