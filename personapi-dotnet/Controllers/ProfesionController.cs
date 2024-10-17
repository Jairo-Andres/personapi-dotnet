// ProfesionController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private readonly ProfesionRepository _repository;

        public ProfesionController(ProfesionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProfesiones()
        {
            var profesiones = _repository.GetAll();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfesion(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return Ok(profesion);
        }

        [HttpPost]
        public IActionResult CreateProfesion([FromBody] Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_repository.Exists(profesion.Id))
            {
                return Conflict("La profesión con este ID ya está registrada. Por favor, elija un ID diferente.");
            }

            _repository.Insert(profesion);
            _repository.Save();
            return CreatedAtAction("GetProfesion", new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfesion(int id, [FromBody] Profesion profesion)
        {
            if (id != profesion.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Update(profesion);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfesion(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            _repository.DeleteProfesion(profesion);
            _repository.Save();
            return NoContent();
        }
    }
}
