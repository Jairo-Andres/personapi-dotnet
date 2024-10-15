using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;

namespace personapi_dotnet.Controllers
{
    public class EstudioViewController : Controller
    {
        private readonly EstudioRepository _repository;

        public EstudioViewController(EstudioRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var estudios = _repository.GetAll();
            return View(estudios);
        }

        public IActionResult Details(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(estudio);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        [HttpGet]
        public IActionResult Edit(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        [HttpPost]
        public IActionResult Edit(Estudio estudio)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(estudio);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        [HttpGet]
        public IActionResult Delete(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            if (estudio == null)
            {
                return NotFound();
            }
            return View(estudio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int idProf, long ccPer)
        {
            var estudio = _repository.GetById(idProf, ccPer);
            _repository.Delete(estudio);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}
