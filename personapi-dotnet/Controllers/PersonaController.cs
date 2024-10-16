using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaRepository _repository;

        public PersonaController(PersonaRepository repository)
        {
            _repository = repository;
        }

        // Método GET para obtener todas las personas
        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personas = _repository.GetAll();
            return Ok(personas); // Devuelve los datos en formato JSON
        }

        // Método GET para obtener una persona por ID
        [HttpGet("{id}")]
        public IActionResult GetPersona(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona); // Devuelve los datos de una persona en formato JSON
        }

        // Método POST para crear una nueva persona
        [HttpPost]
        public IActionResult CreatePersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_repository.Exists(persona.Cc))
            {
                return Conflict("La persona con esta cédula ya está registrada.");
            }

            _repository.Insert(persona);
            _repository.Save();
            return CreatedAtAction("GetPersona", new { id = persona.Cc }, persona);
        }

        // Método PUT para actualizar una persona existente
        [HttpPut("{id}")]
        public IActionResult UpdatePersona(long id, [FromBody] Persona persona)
        {
            if (id != persona.Cc || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.Exists(id))
            {
                return NotFound();
            }

            _repository.Update(persona);
            _repository.Save();
            return NoContent();
        }

        // Método DELETE para eliminar una persona
        [HttpDelete("{id}")]
        public IActionResult DeletePersona(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            _repository.Delete(persona);
            _repository.Save();
            return NoContent();
        }
    }
}