using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/corso")]
    [ApiController]
    public class CorsoController : Controller
    {
        private readonly ICorsoRepository _repo;
        private readonly ScuolaContext _ctx;
        public CorsoController(ICorsoRepository repo, ScuolaContext ctx)
        {
            _repo = repo;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var corsi = await ((CorsoRepository)_repo).GetAllWithRelationsAsync();
            return Ok(corsi);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var corso = await ((CorsoRepository)_repo).GetByIdWithRelationsAsync(id);
            if (corso == null) return NotFound();
            return Ok(corso);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Corso s)
        {
            _repo.Add(s);
            _repo.Save();
            return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Corso s)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            existing.codiceCorso = s.codiceCorso;
            existing.Titolo = s.Titolo;


            _repo.Update(existing);
            _repo.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return NotFound();

            _repo.Delete(s);
            _repo.Save();

            return NoContent();
        }

        [HttpPost("{corsoId}/studenti/{studenteId}")]
        public async Task<IActionResult> AddStudenteToCorso(int corsoId, int studenteId)
        {
            var corso = await _ctx.Corsi
                .Include(c => c.studenti)
                .FirstOrDefaultAsync(c => c.Id == corsoId);

            if (corso == null) return NotFound("Corso non trovato");

            var studente = await _ctx.Studenti.FindAsync(studenteId);
            if (studente == null) return NotFound("Studente non trovato");

            if (!corso.studenti.Any(s => s.Id == studenteId))
                corso.studenti.Add(studente);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // RIMUOVI STUDENTI
        [HttpDelete("{corsoId}/studenti/{studenteId}")]
        public async Task<IActionResult> RemoveStudenteFromCorso(int corsoId, int studenteId)
        {
            var corso = await _ctx.Corsi
                .Include(c => c.studenti)
                .FirstOrDefaultAsync(c => c.Id == corsoId);

            if (corso == null) return NotFound();

            var studente = corso.studenti.FirstOrDefault(s => s.Id == studenteId);
            if (studente != null)
                corso.studenti.Remove(studente);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // AGGIUNGI DOCENTI
        [HttpPost("{corsoId}/docenti/{docenteId}")]
        public async Task<IActionResult> AddDocenteToCorso(int corsoId, int docenteId)
        {
            var corso = await _ctx.Corsi
                .Include(c => c.Docenti)
                .FirstOrDefaultAsync(c => c.Id == corsoId);

            if (corso == null) return NotFound();

            var docente = await _ctx.Docenti.FindAsync(docenteId);
            if (docente == null) return NotFound();

            if (!corso.Docenti.Any(d => d.Id == docenteId))
                corso.Docenti.Add(docente);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // RIMUOVI DOCENTI
        [HttpDelete("{corsoId}/docenti/{docenteId}")]
        public async Task<IActionResult> RemoveDocenteFromCorso(int corsoId, int docenteId)
        {
            var corso = await _ctx.Corsi
                .Include(c => c.Docenti)
                .FirstOrDefaultAsync(c => c.Id == corsoId);

            if (corso == null) return NotFound();

            var docente = corso.Docenti.FirstOrDefault(d => d.Id == docenteId);
            if (docente != null)
                corso.Docenti.Remove(docente);

            await _ctx.SaveChangesAsync();
            return NoContent();

        }
    }
}
