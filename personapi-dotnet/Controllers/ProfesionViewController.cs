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
            if (ModelState.IsValid)
            {
                _repository.Insert(profesion);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(profesion);
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
            if (ModelState.IsValid)
            {
                _repository.Update(profesion);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(profesion);
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
            _repository.Delete(profesion);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
