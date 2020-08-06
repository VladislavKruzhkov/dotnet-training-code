using System.Collections.Generic;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _service;

        private readonly ILogger _logger;

        public SubjectsController(ISubjectService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<SubjectsController>();
        }

        [HttpGet]
        public IEnumerable<SubjectDTO> GetAll()
        {
            _logger.LogInformation("Subjects list requested by user");
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = _service.GetById(id);
            if (subject == null)
            {
                _logger.LogInformation($"Subject with id {id} was not found");
                return NotFound();
            }
            _logger.LogInformation($"Subject with id {id} returned to user");
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult Post(SubjectDTO subject)
        {
            if (subject == null)
            {
                _logger.LogInformation($"Bad request");
                return BadRequest();
            }
            _service.Create(subject);
            _logger.LogInformation($"The subject with name {subject.Name} was created");
            return Ok(subject);
        }

        [HttpPut]
        public IActionResult Put(SubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest();
            }
            if (_service.GetById(subject.SubjectId) == null)
            {
                _logger.LogInformation("The subject is null and can't be updated");
                return NotFound();
            }
            _service.Update(subject);
            _logger.LogInformation($"The subject with id {subject.SubjectId} was updated");
            return Ok(subject);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = _service.GetById(id);
            if (subject == null)
            {
                _logger.LogInformation($"The subject with id {id} is null and can't be deleted");
                return NotFound();
            }
            _service.Delete(id);
            _logger.LogInformation($"The subject with id {id} was deleted");
            return Ok();
        }
    }
}