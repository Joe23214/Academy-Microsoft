using Microsoft.AspNetCore.Mvc;
using ScuolaAPIServer.Repositories;
using ScuolaAPIServer.Models;

namespace ScuolaAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudenteController : ControllerBase
    {
        private readonly IStudenteRepository _repo;

        public StudenteController(IStudenteRepository repo)
        {
            _repo = repo;
        }

        // GET api/studenti
        [HttpGet]
        public ActionResult<IEnumerable<Studente>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/studenti/5
        [HttpGet("{id}")]
        public ActionResult<Studente> GetById(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            return Ok(studente);
        }

        // POST api/studenti
        [HttpPost]
        public ActionResult Create([FromBody] Studente studente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(studente);
            _repo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = studente.Id },
                studente
            );
        }

        // PUT api/studenti/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Studente studente)
        {
            if (id != studente.Id)
                return BadRequest("ID non coerente");

            var existing = _repo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Nome = studente.Nome;
            existing.Cognome = studente.Cognome;
            existing.Matricola = studente.Matricola;
            existing.Età = studente.Età;

            _repo.Update(existing);
            _repo.Save();

            return NoContent();
        }

        // DELETE api/studenti/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var studente = _repo.GetById(id);
            if (studente == null)
                return NotFound();

            _repo.Delete(studente);
            _repo.Save();

            return NoContent();
        }


    }
}
