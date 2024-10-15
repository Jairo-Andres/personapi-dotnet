using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly TelefonoRepository _repository;

        public TelefonoController(TelefonoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetTelefonos()
        {
            var telefonos = _repository.GetAll();
            return Ok(telefonos);
        }

        [HttpGet("{num}")]
        public IActionResult GetTelefono(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return Ok(telefono);
        }

        [HttpPost]
        public IActionResult CreateTelefono([FromBody] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(telefono);
                _repository.Save();
                return CreatedAtAction("GetTelefono", new { num = telefono.Num }, telefono);
            }
            return BadRequest();
        }

        [HttpPut("{num}")]
        public IActionResult UpdateTelefono(string num, [FromBody] Telefono telefono)
        {
            if (num != telefono.Num || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Update(telefono);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{num}")]
        public IActionResult DeleteTelefono(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }
            _repository.Delete(telefono);
            _repository.Save();
            return NoContent();
        }
    }
}
