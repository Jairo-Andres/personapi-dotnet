// PersonaViewController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    public class PersonaViewController : Controller
    {
        private readonly PersonaRepository _repository;

        public PersonaViewController(PersonaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            var personas = _repository.GetAll();
            return View(personas);
        }

        public IActionResult Details(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            if (_repository.Exists(persona.Cc))
            {
                ModelState.AddModelError("Cc", "La persona con esta cédula ya está registrada.");
                return View(persona);
            }

            _repository.Insert(persona);
            _repository.Save();
            TempData["SuccessMessage"] = "Persona creada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            if (!_repository.Exists(persona.Cc))
            {
                return NotFound();
            }

            _repository.Update(persona);
            _repository.Save();
            TempData["SuccessMessage"] = "Persona actualizada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long id)
        {
            var persona = _repository.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }

            _repository.Delete(persona);
            _repository.Save();
            TempData["SuccessMessage"] = "Persona eliminada exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
