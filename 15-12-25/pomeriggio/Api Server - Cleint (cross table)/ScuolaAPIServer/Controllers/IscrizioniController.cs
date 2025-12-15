
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScuolaAPIServer.Data;

namespace ScuolaAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IscrizioniController : ControllerBase
    {
        private readonly ScuolaDbContext _ctx;

        public IscrizioniController(ScuolaDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public IActionResult IscriviStudente(int studenteId, int corsoId)
        {
            var studente = _ctx.Studenti
                .Include(s => s.StudenteCorsi)
                .FirstOrDefault(s => s.Id == studenteId);

            var corso = _ctx.Corsi.Find(corsoId);

            if (studente == null || corso == null)
                return NotFound();

            if (studente.StudenteCorsi.Any(c => c.StudenteId == corsoId))
                return BadRequest("Studente già iscritto al corso");

            studente.StudenteCorsi.Add(new Models.StudenteCorso
            {
                StudenteId = studenteId,
                CorsoId = corsoId
            });
            _ctx.SaveChanges();

            return Ok("Iscrizione completata");
        }
    }
}
