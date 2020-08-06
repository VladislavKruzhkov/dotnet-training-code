using System.Collections.Generic;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        private readonly ILogger _logger;

        public StudentsController(IStudentService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<StudentsController>();
        }

        [HttpGet]
        public IEnumerable<StudentDTO> GetAll()
        {
            _logger.LogInformation("Students list requested by user");
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
            {
                _logger.LogInformation($"Student with id {id} was not found");
                return NotFound();
            }
            _logger.LogInformation($"Student with id {id} returned to user");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(StudentDTO student)
        {
            if (student == null)
            {
                _logger.LogInformation("Bad request");
                return BadRequest();
            }
            _service.Create(student);
            _logger.LogInformation($"The student with name {student.Name} {student.Surname} was created");
            return Ok(student);
        }

        [HttpPut]
        public IActionResult Put(StudentDTO student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            if (_service.GetById(student.StudentId) == null)
            {
                _logger.LogInformation("The student is null and can't be updated");
                return NotFound();
            }
            _service.Update(student);
            _logger.LogInformation($"The student with id {student.StudentId} was updated");
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
            {
                _logger.LogInformation($"The student with id {id} is null and can't be deleted");
                return NotFound();
            }
            _service.Delete(id);
            _logger.LogInformation($"The student with id {id} was deleted");
            return Ok();
        }
    }
}
