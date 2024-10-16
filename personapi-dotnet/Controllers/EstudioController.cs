// EstudioController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private readonly EstudioRepository _repository;

        public EstudioController(EstudioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetEstudios()
        {
            var estudios = _repository.GetAll();
            return Ok(estudios);
        }

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetEstudio(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return Ok(estudio);
        }

        [HttpPost]
        public IActionResult CreateEstudio([FromBody] Estudio estudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_repository.Exists(estudio.IdProf, estudio.CcPer))
            {
                return Conflict("El estudio con esta combinación de ID de profesión y cédula de persona ya está registrado. Por favor, elija valores diferentes.");
            }

            estudio.CcPerNavigation = null;
            estudio.IdProfNavigation = null;

            _repository.Insert(estudio);
            _repository.Save();
            return CreatedAtAction("GetEstudio", new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult UpdateEstudio(int idProf, long ccPer, [FromBody] Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            estudio.CcPerNavigation = null;
            estudio.IdProfNavigation = null;

            _repository.Update(estudio);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult DeleteEstudio(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            _repository.Delete(estudio);
            _repository.Save();
            return NoContent();
        }
    }
}
