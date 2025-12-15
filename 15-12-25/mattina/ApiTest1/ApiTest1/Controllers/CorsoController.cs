using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/corso")]
    [ApiController]
    public class CorsoController : Controller
    {
        private readonly ICorsoRepository _repo;
        public CorsoController(ICorsoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var studenti = _repo.GetAll();
            return Ok(studenti);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return NotFound();
            return Ok(s);
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

            existing.codiceCorso  = s.codiceCorso;
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
    }
}
