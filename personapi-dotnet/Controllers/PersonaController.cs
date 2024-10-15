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

        // M�todo GET para obtener todas las personas
        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personas = _repository.GetAll();
            return Ok(personas); // Devuelve los datos en formato JSON
        }

        // M�todo GET para obtener una persona por ID
        [HttpGet("{id}")]
        public IActionResult GetPersona(int id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona); // Devuelve los datos de una persona en formato JSON
        }

        // M�todo POST para crear una nueva persona
        [HttpPost]
        public IActionResult CreatePersona([FromBody] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(persona);
                _repository.Save();
                return CreatedAtAction("GetPersona", new { id = persona.Cc }, persona);
            }
            return BadRequest();
        }

        // M�todo PUT para actualizar una persona existente
        [HttpPut("{id}")]
        public IActionResult UpdatePersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.Cc || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Update(persona);
            _repository.Save();
            return NoContent();
        }

        // M�todo DELETE para eliminar una persona
        [HttpDelete("{id}")]
        public IActionResult DeletePersona(int id)
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
