using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class CorsoController : Controller
    {

        private readonly IRepository<Corso> _repo;

        public CorsoController(IRepository<Corso> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var corsi = _repo.GetAll();
            return View(corsi);
        }

        public IActionResult Details(int id)
        {
            var corso = _repo.GetById(id);
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

    }
}
