using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class StudenteController : Controller
    {
        private readonly IRepository<Studente> _repo;

        public StudenteController(IRepository<Studente> repo)
        {
            _repo = repo;
        }

        // GET: /Studente/
        public IActionResult Index()
        {
            var studenti = _repo.GetAll();
            return View(studenti);
        }

        // GET: /Studente/Details/5
        public IActionResult Details(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // GET: /Studente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Studente/Create
        [HttpPost]
        public IActionResult Create(Studente s)
        {
            if (!ModelState.IsValid)
                return View(s);

            _repo.Add(s);
            _repo.Save();
            return RedirectToAction("Index");
        }

        // GET: /Studente/Edit/5
        public IActionResult Edit(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // POST: /Studente/Edit
        [HttpPost]
        public IActionResult Edit(Studente s)
        {
            if (!ModelState.IsValid)
                return View(s);

            var existing = _repo.GetById(s.Id);
            if (existing == null)
                return NotFound();

            existing.Nome = s.Nome;
            existing.Eta = s.Eta;

            // Se hai Cognome o altri campi:
            existing.Cognome = s.Cognome;

            _repo.Update(existing);
            _repo.Save();

            return RedirectToAction("Index");
        }

        // GET: /Studente/Delete/5
        public IActionResult Delete(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            return View(studente);
        }

        // POST: /Studente/DeleteConfirmed/5
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

        //relazioni

    }
}
