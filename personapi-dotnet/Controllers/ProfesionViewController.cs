// ProfesionViewController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    public class ProfesionViewController : Controller
    {
        private readonly ProfesionRepository _repository;

        public ProfesionViewController(ProfesionRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            var profesiones = _repository.GetAll();
            return View(profesiones);
        }

        public IActionResult Details(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return View(profesion);
            }

            if (_repository.Exists(profesion.Id))
            {
                ModelState.AddModelError("Id", "La profesión con este ID ya está registrada. Por favor, elija un ID diferente.");
                return View(profesion);
            }

            _repository.Insert(profesion);
            _repository.Save();
            TempData["SuccessMessage"] = "Profesión creada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        [HttpPost]
        public IActionResult Edit(Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return View(profesion);
            }

            _repository.Update(profesion);
            _repository.Save();
            TempData["SuccessMessage"] = "Profesión actualizada exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return View(profesion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var profesion = _repository.GetById(id);
            if (profesion == null)
            {
                return NotFound();
            }

            _repository.Delete(profesion);
            _repository.Save();
            TempData["SuccessMessage"] = "Profesión eliminada exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
