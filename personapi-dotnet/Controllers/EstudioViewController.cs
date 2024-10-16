// EstudioViewController.cs
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
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
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
            if (!ModelState.IsValid)
            {
                return View(estudio);
            }

            if (_repository.Exists(estudio.IdProf, estudio.CcPer))
            {
                ModelState.AddModelError("IdProf", "El estudio con esta combinación de ID de profesión y cédula de persona ya está registrado. Por favor, elija valores diferentes.");
                return View(estudio);
            }

            estudio.CcPerNavigation = null;
            estudio.IdProfNavigation = null;

            _repository.Insert(estudio);
            _repository.Save();
            TempData["SuccessMessage"] = "Estudio creado exitosamente.";
            return RedirectToAction("Index");
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
            if (!ModelState.IsValid)
            {
                return View(estudio);
            }

            estudio.CcPerNavigation = null;
            estudio.IdProfNavigation = null;

            _repository.Update(estudio);
            _repository.Save();
            TempData["SuccessMessage"] = "Estudio actualizado exitosamente.";
            return RedirectToAction("Index");
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
            if (estudio == null)
            {
                return NotFound();
            }

            _repository.Delete(estudio);
            _repository.Save();
            TempData["SuccessMessage"] = "Estudio eliminado exitosamente.";
            return RedirectToAction("Index");
        }
    }
}