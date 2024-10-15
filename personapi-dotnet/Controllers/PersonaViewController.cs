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
			var personas = _repository.GetAll();
			return View(personas);
		}

		public IActionResult Details(int id)
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
			if (ModelState.IsValid)
			{
				_repository.Insert(persona);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View(persona);
		}

		[HttpGet]
		public IActionResult Edit(int id)
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
			if (ModelState.IsValid)
			{
				_repository.Update(persona);
				_repository.Save();
				return RedirectToAction("Index");
			}
			return View(persona);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var persona = _repository.GetById(id);
			if (persona == null)
			{
				return NotFound();
			}
			return View(persona);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var persona = _repository.GetById(id);
			_repository.Delete(persona);
			_repository.Save();
			return RedirectToAction("Index");
		}
	}
}
