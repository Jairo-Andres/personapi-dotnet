// TelefonoViewController.cs
using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    public class TelefonoViewController : Controller
    {
        private readonly TelefonoRepository _repository;

        public TelefonoViewController(TelefonoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            var telefonos = _repository.GetAll();
            return View(telefonos);
        }

        public IActionResult Details(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            if (!ModelState.IsValid)
            {
                return View(telefono);
            }

            if (_repository.Exists(telefono.Num))
            {
                ModelState.AddModelError("Num", "El teléfono con este número ya está registrado. Por favor, elija un número diferente.");
                return View(telefono);
            }

            telefono.DuenioNavigation = null;

            _repository.Insert(telefono);
            _repository.Save();
            TempData["SuccessMessage"] = "Teléfono creado exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            if (!ModelState.IsValid)
            {
                return View(telefono);
            }

            telefono.DuenioNavigation = null;

            _repository.Update(telefono);
            _repository.Save();
            TempData["SuccessMessage"] = "Teléfono actualizado exitosamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string num)
        {
            var telefono = _repository.GetById(num);
            if (telefono == null)
            {
                return NotFound();
            }

            _repository.Delete(telefono);
            _repository.Save();
            TempData["SuccessMessage"] = "Teléfono eliminado exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
