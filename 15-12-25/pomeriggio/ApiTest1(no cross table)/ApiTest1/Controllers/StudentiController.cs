using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
  
        
        [Route("api/studente")]
        [ApiController] 
        public class StudenteController : ControllerBase 
        {
        private readonly IStudenteRepository _repo;
        private readonly ScuolaContext _ctx;
        public StudenteController(IStudenteRepository repo, ScuolaContext ctx)
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
            public IActionResult Create([FromBody] Studente s) 
            {
                _repo.Add(s);
                _repo.Save();
                return CreatedAtAction(nameof(Get), new { id = s.Id }, s); 
            }

           
            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] Studente s)
            {
                var existing = _repo.GetById(id);
                if (existing == null) return NotFound();

                existing.Nome = s.Nome;
                existing.Cognome = s.Cognome;
                existing.Eta = s.Eta;
                existing.Matricola = s.Matricola;

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

        [HttpPost("{studenteId}/corsi/{corsoId}")]
        public async Task<IActionResult> AddCorso(int studenteId, int corsoId)
        {
            var studente = await _repo.GetByIdWithRelationsAsync(studenteId);
            if (studente == null) return NotFound();

            var corso = await _ctx.Corsi.FindAsync(corsoId);
            if (corso == null) return NotFound();

            if (!studente.Corsi.Any(c => c.Id == corsoId))
                studente.Corsi.Add(corso);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{studenteId}/corsi/{corsoId}")]
        public async Task<IActionResult> RemoveCorso(int studenteId, int corsoId)
        {
            var studente = await _repo.GetByIdWithRelationsAsync(studenteId);
            if (studente == null) return NotFound();

            var corso = studente.Corsi.FirstOrDefault(c => c.Id == corsoId);
            if (corso != null)
                studente.Corsi.Remove(corso);

            await _ctx.SaveChangesAsync();
            return NoContent();
        }


    }
}

