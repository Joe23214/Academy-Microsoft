using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Client.Controllers
{
    public class CorsoController : ApiControllerBase
    {
        public CorsoController(IHttpClientFactory factory) : base(factory) { }

        // GET: /Corso
        public async Task<IActionResult> Index()
        {
            var res = await _client.GetAsync("api/corso");
            if (!res.IsSuccessStatusCode) return View(new List<Corso>());

            var json = await res.Content.ReadAsStringAsync();
            var corsi = JsonSerializer.Deserialize<List<Corso>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(corsi);
        }

        // GET: /Corso/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var res = await _client.GetAsync($"api/corso/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var corso = JsonSerializer.Deserialize<Corso>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(corso);
        }

        // GET: /Corso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Corso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Corso model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/corso", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        // GET: /Corso/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"api/corso/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var corso = JsonSerializer.Deserialize<Corso>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(corso);
        }

        // POST: /Corso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Corso model)
        {
            if (id != model.Id) return BadRequest();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/corso/{id}", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        // GET: /Corso/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _client.GetAsync($"api/corso/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var corso = JsonSerializer.Deserialize<Corso>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(corso);
        }

        // POST: /Corso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = await _client.DeleteAsync($"api/corso/{id}");
            return RedirectToAction(nameof(Index));
        }

        // GET: /Corso/AddStudenti/5 (pagina form)
        public async Task<IActionResult> AddStudenti(int id)
        {
            // corso
            var resCorso = await _client.GetAsync($"api/corso/{id}");
            if (!resCorso.IsSuccessStatusCode) return NotFound();

            var corsoJson = await resCorso.Content.ReadAsStringAsync();
            var corso = JsonSerializer.Deserialize<Corso>(corsoJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // tutti gli studenti
            var resStud = await _client.GetAsync("api/studente");
            var studJson = await resStud.Content.ReadAsStringAsync();
            var studenti = JsonSerializer.Deserialize<List<Studente>>(studJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewBag.Studenti = studenti;
            return View(corso);
        }

        // POST: /Corso/AddStudenti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudenti(int corsoId, int studenteId)
        {
            var res = await _client.PostAsync(
                $"api/corso/{corsoId}/studenti/{studenteId}", null);

            return RedirectToAction(nameof(Details), new { id = corsoId });
        }

        // GET: /Corso/AddDocenti/5
        public async Task<IActionResult> AddDocenti(int id)
        {
            var resCorso = await _client.GetAsync($"api/corso/{id}");
            if (!resCorso.IsSuccessStatusCode) return NotFound();

            var corsoJson = await resCorso.Content.ReadAsStringAsync();
            var corso = JsonSerializer.Deserialize<Corso>(corsoJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var resDoc = await _client.GetAsync("api/docente");
            var docJson = await resDoc.Content.ReadAsStringAsync();
            var docenti = JsonSerializer.Deserialize<List<Docente>>(docJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewBag.Docenti = docenti;
            return View(corso);
        }

        // POST: /Corso/AddDocenti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDocenti(int corsoId, int docenteId)
        {
            var res = await _client.PostAsync(
                $"api/corso/{corsoId}/docenti/{docenteId}", null);

            return RedirectToAction(nameof(Details), new { id = corsoId });
        }

        public async Task<IActionResult> RemoveStudente(int corsoId, int studenteId)
        {
            await _client.DeleteAsync($"api/corso/{corsoId}/studenti/{studenteId}");
            return RedirectToAction(nameof(Details), new { id = corsoId });
        }

        // Stesso per docenti
        public async Task<IActionResult> RemoveDocente(int corsoId, int docenteId)
        {
            await _client.DeleteAsync($"api/corso/{corsoId}/docenti/{docenteId}");
            return RedirectToAction(nameof(Details), new { id = corsoId });
        }
    }
}
