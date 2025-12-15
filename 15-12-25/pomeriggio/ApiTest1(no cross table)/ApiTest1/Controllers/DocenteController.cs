using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/docente")]
    [ApiController]
    public class DocenteController : Controller
    {
        private readonly IDocenteRepository _repo;
        private readonly ScuolaContext _ctx;
        public DocenteController(IDocenteRepository repo, ScuolaContext ctx)
        {
            _repo = repo;
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var studenti = _repo.GetAll();
            return Ok(studenti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _repo.GetByIdWithRelationsAsync(id);
            if (s == null) return NotFound();
            return Ok(s);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Docente s) 
        {
            _repo.Add(s);
            _repo.Save();
            return CreatedAtAction(nameof(Get), new { id = s.Id }, s); 
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Docente s)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            existing.Name = s.Name;


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

        [HttpPost("{docenteId}/corsi/{corsoId}")]
        public async Task<IActionResult> AddCorso(int docenteId, int corsoId)
        {
            var docente = await _ctx.Docenti.Include(d => d.corsi)
                .FirstOrDefaultAsync(d => d.Id == docenteId);
            if (docente == null) return NotFound();

            var corso = await _ctx.Corsi.FindAsync(corsoId);
            if (corso == null) return NotFound();

            if (!docente.corsi.Any(c => c.Id == corsoId))
                docente.corsi.Add(corso);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{docenteId}/corsi/{corsoId}")]
        public async Task<IActionResult> RemoveCorso(int docenteId, int corsoId)
        {
            var docente = await _ctx.Docenti.Include(d => d.corsi)
                .FirstOrDefaultAsync(d => d.Id == docenteId);
            if (docente == null) return NotFound();

            var corso = docente.corsi.FirstOrDefault(c => c.Id == corsoId);
            if (corso != null)
                docente.corsi.Remove(corso);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

    }
}
