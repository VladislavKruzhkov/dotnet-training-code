using System.Collections.Generic;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _service;
        
        private readonly ILogger _logger;

        public ProfessorsController(IProfessorService service, ILoggerFactory loggerFactory)
        {
            _service = service;
            _logger = loggerFactory.CreateLogger<ProfessorsController>();
        }

        [HttpGet]
        public IEnumerable<ProfessorDTO> GetAll()
        {
            _logger.LogInformation("Professors list requested by user");
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _service.GetById(id);
            if (professor == null)
            {
                _logger.LogInformation($"Professor with id {id} was not found");
                return NotFound();
            }
            _logger.LogInformation($"Professor with id {id} returned to user");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(ProfessorDTO professor)
        {
            if (professor == null)
            {
                _logger.LogInformation("Bad request");
                return BadRequest();
            }
            _service.Create(professor);
            _logger.LogInformation($"The professor with name {professor.Name} {professor.Surname} was created");
            return Ok(professor);
        }

        [HttpPut]
        public IActionResult Put(ProfessorDTO professor)
        {
            if (professor == null)
            {
                return BadRequest();
            }
            if (_service.GetById(professor.ProfessorId) == null)
            {
                _logger.LogInformation("The professor is null and can't be updated");
                return NotFound();
            }
            _service.Update(professor);
            _logger.LogInformation($"The professor with id {professor.ProfessorId} was updated");
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _service.GetById(id);
            if (professor == null)
            {
                _logger.LogInformation($"The professor with id {id} is null and can't be deleted");
                return NotFound();
            }
            _service.Delete(id);
            _logger.LogInformation($"The professor with id {id} was deleted");
            return Ok();
        }
    }
}