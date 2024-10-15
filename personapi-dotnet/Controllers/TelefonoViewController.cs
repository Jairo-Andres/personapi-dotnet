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
            if (ModelState.IsValid)
            {
                _repository.Insert(telefono);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(telefono);
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
            if (ModelState.IsValid)
            {
                _repository.Update(telefono);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(telefono);
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
            _repository.Delete(telefono);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
