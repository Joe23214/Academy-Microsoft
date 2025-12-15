using Microsoft.AspNetCore.Mvc;
using ScuolaAPIServer.Repositories;
using ScuolaAPIServer.Models;

namespace ScuolaAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoreController : ControllerBase
    {
        private readonly IProfessoreRepository _repo;

        public ProfessoreController(IProfessoreRepository repo)
        {
            _repo = repo;
        }

        // GET api/studenti
        [HttpGet]
        public ActionResult<IEnumerable<Professore>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

        // GET api/studenti/5
        [HttpGet("{id}")]
        public ActionResult<Professore> GetById(int id)
        {
            var Professore = _repo.GetById(id);
            if (Professore == null)
                return NotFound();

            return Ok(Professore);
        }

        // POST api/studenti
        [HttpPost]
        public ActionResult Create([FromBody] Professore Professore)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repo.Add(Professore);
            _repo.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = Professore.Id },
                Professore
            );
        }

        // PUT api/studenti/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Professore Professore)
        {
            if (id != Professore.Id)
                return BadRequest("ID non coerente");

            var existing = _repo.GetById(id);
            if (existing == null)
                return NotFound();

            existing.Nome = Professore.Nome;
            existing.Cognome = Professore.Cognome;

            _repo.Update(existing);
            _repo.Save();

            return NoContent();
        }

        // DELETE api/studenti/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Professore = _repo.GetById(id);
            if (Professore == null)
                return NotFound();

            _repo.Delete(Professore);
            _repo.Save();

            return NoContent();
        }
    }


}