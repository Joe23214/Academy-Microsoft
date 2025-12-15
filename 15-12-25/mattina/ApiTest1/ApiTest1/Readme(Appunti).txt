Appunti api c#:
	YourSolution/
│
├── API/                  <-- progetto indipendente
│     ├── Controllers/
│     ├── Models/
│     ├── Data/
│     └── Repositories/
│
├── MVC/                  <-- la web app che avevi prima (opzionale)
│     ├── Controllers/
│     ├── Views/
│     ├── Models/
│     ├── Data/
│
└── Repositories/
 
File → New Project → ASP.NET Core Web API
Framework: .NET 
 
TI ASSICURI di SPUNTARE:
 
“Enable OpenAPI support”
“No Authentication”
 
IMPORTI I MODELLI E IL REPOSITORY
API/Models/
API/Data/ScuolaContext.cs
API/Repositories/
 
CREI I CONTROLLER
- API/Controllers/StudentiController.cs
non restituisco con return View(studenti); ma con return Ok(studenti);
- API/Controllers/CorsiController.cs
 
CONFIGURI IL FILE PROGRAM.CS
 
 
VANTAGGI:
Gli endpoint sono chiamati esplicitamente
GET /api/studente restituisce JSON
POST /api/studente crea un record
PUT aggiorna
DELETE elimina
 
Zero HTML, zero Views: solo dati.
 
TEST DEGLI ENDPOINT
Avvia il progetto (F5)
Vai a https://localhost:{PORTA}/swagger
/swagger/index.html
oppure
https://localhost:{PORTA}/swagger/index.html
 
	






/*  Questo è uno standard RESTful per la creazione, lettura, aggiornamento e cancellazione di dati (CRUD).
 
 * 
il Controller: Gestisce le richieste HTTP(GET, POST, PUT, DELETE, PATCH) per uno specifico modello (Studente).
I repository: Si occupano di interagire con il database.
ActionResult: Le azioni nel controller restituiscono risposte HTTP (come Ok(), NotFound(), CreatedAtAction(), NoContent()).
 
*/
 
/* Perchè derivo da ControllerBase e non da Controller? Brevemente: non servono, e qui farebbero solo confusione.
 * 
 * Usa Controller solo in MVC.
 * Usa ControllerBase per le API.
 * Aggiungi [ApiController] per il comportamento REST completo.
 * 
 * ControllerBase contiene solo le feature necessarie a un’API REST, tra cui:
         Ok()
         NotFound()
         CreatedAtAction()
         NoContent()
         BadRequest()
         StatusCode()
 
- non usa le View Razor
- non restituisce HTML
- non ha bisogno dei metodi per la ViewEngine
- restituisce JSON
- risponde ai client esterni, non ai browser
 */
 
 Controller:
using apiScuolaWebMVC.Models;
using apiScuolaWebMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
 
namespace apiScuolaWebMVC.Controllers
{
    //[Route("api/[controller]")] //risponde agli endpoint che iniziano con api/studente 
    [Route("api/studente")]
    [ApiController] //indica che è un controller per API (non MVC)
    public class StudenteApiController : ControllerBase //deriva da ControllerBase (non da Controller)
    {
        //Riferimento al repository
        private readonly IStudenteRepository _repo;
 
        //Inietto il repository tramite costruttore in automatico (through Dependency Injection) 
        public StudenteApiController(IStudenteRepository repo)
        {
            _repo = repo;
        }
 
        // GET: api/studente
        [HttpGet]
        public IActionResult GetAll()
        {
            var studenti = _repo.GetAll();
            return Ok(studenti);
        }
 
        // GET: api/studente/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var s = _repo.GetById(id);
            if (s == null) return NotFound();
            return Ok(s);
        }
 
        // POST: api/studente
        [HttpPost]
        public IActionResult Create([FromBody] Studente s) //[FromBody] indica che i dati arrivano nel corpo della richiesta
        {
            _repo.Add(s);
            _repo.Save();
            return CreatedAtAction(nameof(Get), new { id = s.Id }, s); //ritorna 201 Created con header Location
        }
 
        // PUT: api/studente/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Studente s)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();
 
            existing.Nome = s.Nome;
            existing.Cognome = s.Cognome;
            existing.Eta = s.Eta;
 
            _repo.Update(existing);
            _repo.Save();
 
            return NoContent();
        }
 
        // DELETE: api/studente/5
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
_Program:
using apiScuolaWebMVC.Data;
using apiScuolaWebMVC.Repositories;
using Microsoft.EntityFrameworkCore;
 
namespace apiScuolaWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
 
            // 1. Controller API
            builder.Services.AddControllers();
 
            // 2. OpenAPI / Swagger
            // builder.Services.AddOpenApi(); // non può essere usato insieme a Swagger classico
 
            // Swagger classico (compatibile con Swashbuckle) 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
 
            // 3. DbContext (EF Core)
            builder.Services.AddDbContext<ScuolaContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );
 
            // 4. Repository pattern
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IStudenteRepository, StudenteRepository>();
            builder.Services.AddScoped<ICorsoRepository, CorsoRepository>();
            builder.Services.AddScoped<IDocenteRepository, DocenteRepository>();
 
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll", builder =>
            //        builder.AllowAnyOrigin()
            //               .AllowAnyMethod()
            //               .AllowAnyHeader());
            //});
            var app = builder.Build();
            app.UseCors("AllowAll");
            // 5. Swagger attivo in Development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //     app.MapOpenApi();     // non può essere usato insieme a Swagger classico
            }
 
            // 6. Pipeline API
            app.UseHttpsRedirection();
            app.UseAuthorization();
 
 
            //AppDomain.CurrentDomain.FirstChanceException += (sender, e) =>
            //{
            //    Console.WriteLine("EXCEPTION: " + e.Exception.GetType().FullName);
            //    Console.WriteLine(e.Exception.Message);
            //};
 
            // 7. Routing API
            app.MapControllers();
 
            app.Run();
        }
    }
}
_
controller associazione
Programusing apiScuolaWebMVC.Models;
using apiScuolaWebMVC.Data;
using Microsoft.AspNetCore.Mvc;
 
namespace apiScuolaWebMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IscrizioniStudentiApiController : ControllerBase
    {
        private readonly ScuolaContext _context;
        public IscrizioniStudentiApiController(ScuolaContext context)
        {
            _context = context;
        }
 
        //GET: api/iscrizionistudenti/5
        // Restituisce la lista dei corsi dello studente
 
        [HttpGet("{id}")]
        public IActionResult GetCorsiStudente(int studenteId)
        {
            var studente = _context.Studenti.Find(studenteId);
            if (studente == null)
                return new NotFoundResult();
            var corsi = _context.StudentiCorsi
                .Where(sc => sc.StudenteId == studenteId)
                .Select(sc => sc.Corso)
                .ToList();  
 
            return Ok(corsi);
        }
        // GET: api/iscrizioni/studenti/5/disponibili
        // Restituisce i corsi NON assegnati allo studente
        [HttpGet("studente/{studenteId}/disponibili")]
        public IActionResult GetCorsiDisponibili(int studenteId)
        {
            var studente = _context.Studenti.Find(studenteId);
            if (studente == null)
                return NotFound($"Studente {studenteId} non trovato");
 
            var assegnati = _context.StudentiCorsi
                .Where(sc => sc.StudenteId == studenteId)
                .Select(sc => sc.CorsoId)
                .ToList();
 
            var disponibili = _context.Corsi
                .Where(c => !assegnati.Contains(c.Id))
                .ToList();
 
            return Ok(disponibili);
        }
 
        // POST: api/iscrizioni/studenti
        // Aggiunge iscrizione (StudenteId + CorsoId)
        [HttpPost]
        public IActionResult AggiungiIscrizione([FromBody] IscrizioneStudenteDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
 
            var exists = _context.StudentiCorsi
                .Any(x => x.StudenteId == dto.StudenteId && x.CorsoId == dto.CorsoId);
 
            if (exists)
                return Conflict("Lo studente è già iscritto a questo corso.");
 
            var sc = new StudenteCorso
            {
                StudenteId = dto.StudenteId,
                CorsoId = dto.CorsoId
            };
 
            _context.StudentiCorsi.Add(sc);
            _context.SaveChanges();
 
            return Created($"api/iscrizioni/studenti/{dto.StudenteId}", sc);
        }
 
 
        // DELETE: api/iscrizioni/studenti/5/corso/7
        // rimuove l'iscrizione
        [HttpDelete("studente/{studenteId}/corso/{corsoId}")]
        public IActionResult Remove(int studenteId, int corsoId)
        {
            var record = _context.StudentiCorsi
                .FirstOrDefault(sc => sc.StudenteId == studenteId && sc.CorsoId == corsoId);
 
            if (record == null)
                return NotFound("Iscrizione non trovata");
 
            _context.StudentiCorsi.Remove(record);
            _context.SaveChanges();
 
            return NoContent();
        }
    }
}
_
using apiScuolaWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ScuolaMVCclient.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
 
public class StudenteController : Controller
{
    private readonly HttpClient _httpClient;
 
    public StudenteController(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("ScuolaApi");
    }
 
    // GET: Studente
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("studente");
        response.EnsureSuccessStatusCode();
 
        var json = await response.Content.ReadAsStringAsync();
        var studenti = JsonSerializer.Deserialize<List<Studente>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
 
        return View(studenti);
    }
 
    // GET: Studente/Create
    public IActionResult Create()
    {
        return View();
    }
 
    // POST: Studente/Create
    [HttpPost]
    public async Task<IActionResult> Create(Studente studente)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(studente),
            Encoding.UTF8,
            "application/json");
 
        var response = await _httpClient.PostAsync("studente", jsonContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
 
        return View(studente);
    }
 
    // GET: Studente/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var response = await _httpClient.GetAsync($"studente/{id}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var studente = JsonSerializer.Deserialize<Studente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(studente);
        }
 
        return NotFound();
    }
 
    // POST: Studente/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Studente studente)
    {
        var jsonContent = new StringContent(
            JsonSerializer.Serialize(studente),
            Encoding.UTF8,
            "application/json");
 
        var response = await _httpClient.PutAsync($"studente/{id}", jsonContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
 
        return View(studente);
    }
 
    // GET: Studente/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.GetAsync($"studente/{id}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var studente = JsonSerializer.Deserialize<Studente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(studente);
        }
 
        return NotFound();
    }
 
    // POST: Studente/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _httpClient.DeleteAsync($"studente/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
 
        return NotFound();
    }
}
 
_context
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using ScuolaMVCclient.Models;
using apiScuolaWebMVC.Models;
 
namespace ScuolaMVCclient.Controllers
{
    public class IscrizioniDocentiController : Controller
    {
        private readonly HttpClient _httpClient;
 
        public IscrizioniDocentiController(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("ScuolaApi");
        }
 
        // GET: IscrizioniDocenti/DocenteCorsi/5
        public async Task<IActionResult> DocenteCorsi(int docenteId)
        {
            // Ottieni corsi assegnati al docente
            var response = await _httpClient.GetAsync($"iscrizioni/docenti/docente/{docenteId}");
            response.EnsureSuccessStatusCode();
 
            var json = await response.Content.ReadAsStringAsync();
            var corsi = JsonSerializer.Deserialize<List<Corso>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
 
            return View(corsi);
        }
 
        // GET: IscrizioniDocenti/DocenteCorsiDisponibili/5
        public async Task<IActionResult> DocenteCorsiDisponibili(int docenteId)
        {
            // Ottieni corsi non assegnati al docente
            var response = await _httpClient.GetAsync($"iscrizioni/docenti/docente/{docenteId}/disponibili");
            response.EnsureSuccessStatusCode();
 
            var json = await response.Content.ReadAsStringAsync();
            var corsiDisponibili = JsonSerializer.Deserialize<List<Corso>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
 
            return View(corsiDisponibili);
        }
 
        // POST: IscrizioniDocenti/AggiungiCorsoDocente
        [HttpPost]
        public async Task<IActionResult> AggiungiCorsoDocente([FromBody] AssociazioneDocenteDTO docenteCorso)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(docenteCorso),
                Encoding.UTF8,
                "application/json");
 
            var response = await _httpClient.PostAsync("iscrizioni/docenti", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(DocenteCorsi), new { docenteId = docenteCorso.DocenteId });
            }
 
            return BadRequest();
        }
 
        // POST: IscrizioniDocenti/RimuoviCorsoDocente
        [HttpPost]
        public async Task<IActionResult> RimuoviCorsoDocente(int docenteId, int corsoId)
        {
            var response = await _httpClient.DeleteAsync($"iscrizioni/docenti/docente/{docenteId}/corso/{corsoId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(DocenteCorsi), new { docenteId });
            }
 
            return BadRequest();
        }
    }
}