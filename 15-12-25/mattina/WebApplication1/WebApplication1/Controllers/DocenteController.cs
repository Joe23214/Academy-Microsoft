using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class DocenteController : Controller
    {
        private readonly IRepository<Docente> _repo;
        public DocenteController(IRepository<Docente> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var docenti = _repo.GetAll();
            return View(docenti);
        }

        public IActionResult Details(int id)
        {
            var docente = _repo.GetById(id);
            if (docente == null)
                return NotFound();

            return View(docente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Docente d)
        {
            if (!ModelState.IsValid)
                return View(d);

            _repo.Add(d);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var docente = _repo.GetById(id);
            if (docente == null)
                return NotFound();

            return View(docente);
        }

        [HttpPost]
        public IActionResult Edit(Docente d)
        {
            if (!ModelState.IsValid)
                return View(d);

            var existing = _repo.GetById(d.Id);
            if (existing == null)
                return NotFound();

            existing.Name = d.Name;


            _repo.Update(existing);
            _repo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            _repo.Delete(studente);
            _repo.Save();

            return RedirectToAction("Index");
        }
    }
}
