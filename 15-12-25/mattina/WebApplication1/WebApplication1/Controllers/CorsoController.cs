using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CorsoController : Controller
    {

        private readonly IRepository<Corso> _repo;
        private readonly ScuolaContext _context;

        public CorsoController(IRepository<Corso> repo, ScuolaContext context)
        {
            _repo = repo;
            _context = context;
        }

        public IActionResult Index()
        {
            var corsi = _repo.GetAll();
            return View(corsi);
        }

        public IActionResult Details(int id)
        {
            var corso = _context.Corsi
                .Include(c => c.studenti)
                .Include(c => c.Docenti)
                .FirstOrDefault(c => c.Id == id);

            if (corso == null)
                return NotFound();

            return View(corso);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Corso c)
        {
            if (!ModelState.IsValid)
                return View(c);

            _repo.Add(c);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var corso = _repo.GetById(id);
            if (corso == null)
                return NotFound();

            return View(corso);
        }

        [HttpPost]
        public IActionResult Edit(Corso c)
        {
            if (!ModelState.IsValid)
                return View(c);

            var existing = _repo.GetById(c.Id);
            if (existing == null)
                return NotFound();

            existing.codiceCorso  = c.codiceCorso;
            existing.Titolo = c.Titolo;

            _repo.Update(existing);
            _repo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var corso = _repo.GetById(id);
            if (corso == null)
                return NotFound();

            return View(corso);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var corso = _repo.GetById(id);
            if (corso == null)
                return NotFound();

            _repo.Delete(corso);
            _repo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult AddStudenti(int id)
        {
            var corso = _context.Corsi
                .Include(c => c.studenti)
                .FirstOrDefault(c => c.Id == id);

            if (corso == null)
                return NotFound();

            ViewBag.Studenti = _context.Studenti.ToList();
            return View(corso);
        }

        [HttpPost]
        public IActionResult AddStudenti(int corsoId, int studenteId)
        {
            var corso = _context.Corsi
                .Include(c => c.studenti)
                .First(c => c.Id == corsoId);

            var studente = _context.Studenti.Find(studenteId);

            if (!corso.studenti.Contains(studente))
            {
                corso.studenti.Add(studente);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddDocenti(int id)
        {
            var corso = _context.Corsi
                .Include(c => c.Docenti)
                .FirstOrDefault(c => c.Id == id);

            if (corso == null)
                return NotFound();

            ViewBag.Docenti = _context.Docenti.ToList();
            return View(corso);
        }

        [HttpPost]
        public IActionResult AddDocenti(int corsoId, int docenteId)
        {
            var corso = _context.Corsi
                .Include(c => c.Docenti)
                .First(c => c.Id == corsoId);

            var docente = _context.Docenti.Find(docenteId);

            if (!corso.Docenti.Contains(docente))
            {
                corso.Docenti.Add(docente);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
