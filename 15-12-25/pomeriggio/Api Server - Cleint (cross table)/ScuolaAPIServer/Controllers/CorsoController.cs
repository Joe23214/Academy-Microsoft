using Microsoft.AspNetCore.Mvc;
using ScuolaAPIServer.Repositories;
using ScuolaAPIServer.Models;

namespace ScuolaAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorsoController : ControllerBase
    {
        private readonly ICorsoRepository _repo;

        public CorsoController(ICorsoRepository repo)
        {
            _repo = repo;
        }

        // GET api/corsi
        [HttpGet]
        public ActionResult<IEnumerable<Corso>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/corsi/5
        [HttpGet("{id}")]
        public ActionResult<Corso> GetById(int id)
        {
            var Corso = _repo.GetById(id);
            if (Corso == null)
                return NotFound();

            return Ok(Corso);
        }

        // POST api/corsi
        [HttpPost]
        public ActionResult Create([FromBody] Corso Corso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(Corso);
            _repo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = Corso.Id },
                Corso
            );
        }

        // PUT api/corsi/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Corso Corso)
        {
            if (id != Corso.Id)
                return BadRequest("ID non coerente");

            var existing = _repo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Codice = Corso.Codice;
            existing.Nome = Corso.Nome;


            _repo.Update(existing);
            _repo.Save();

            return NoContent();
        }

        // DELETE api/corsi/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Corso = _repo.GetById(id);
            if (Corso == null)
                return NotFound();

            _repo.Delete(Corso);
            _repo.Save();

            return NoContent();
        }
    }
}