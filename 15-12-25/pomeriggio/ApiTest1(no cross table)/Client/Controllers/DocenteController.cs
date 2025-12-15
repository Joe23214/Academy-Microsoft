using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Client.Controllers
{
    public class DocenteController : ApiControllerBase
    {
        public DocenteController(IHttpClientFactory factory) : base(factory) { }

        public async Task<IActionResult> Index()
        {
            var res = await _client.GetAsync("api/docente");
            var json = await res.Content.ReadAsStringAsync();
            var docenti = JsonSerializer.Deserialize<List<Docente>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(docenti);
        }

        public async Task<IActionResult> Details(int id)
        {
            var res = await _client.GetAsync($"api/docente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var docente = JsonSerializer.Deserialize<Docente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(docente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Docente model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/docente", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"api/docente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var docente = JsonSerializer.Deserialize<Docente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(docente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Docente model)
        {
            if (id != model.Id) return BadRequest();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/docente/{id}", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var res = await _client.GetAsync($"api/docente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var docente = JsonSerializer.Deserialize<Docente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(docente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _client.DeleteAsync($"api/docente/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddCorsi(int id)
        {
            var docente = await _client.GetFromJsonAsync<Docente>($"api/docente/{id}");
            var corsi = await _client.GetFromJsonAsync<List<Corso>>("api/corso");
            ViewBag.Corsi = corsi;
            return View(docente);
        }

        [HttpPost]
        public async Task<IActionResult> AddCorsi(int docenteId, int corsoId)
        {
            await _client.PostAsync($"api/docente/{docenteId}/corsi/{corsoId}", null);
            return RedirectToAction(nameof(Details), new { id = docenteId });
        }

        public async Task<IActionResult> RemoveCorso(int docenteId, int corsoId)
        {
            await _client.DeleteAsync($"api/docente/{docenteId}/corsi/{corsoId}");
            return RedirectToAction(nameof(Details), new { id = docenteId });
        }

    }
}
