using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Client.Controllers
{
    public class StudenteController : ApiControllerBase
    {
        public StudenteController(IHttpClientFactory factory) : base(factory) { }

        public async Task<IActionResult> Index()
        {
            var res = await _client.GetAsync("api/studente");
            var json = await res.Content.ReadAsStringAsync();
            var studenti = JsonSerializer.Deserialize<List<Studente>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(studenti);
        }

        public async Task<IActionResult> Details(int id)
        {
            var res = await _client.GetAsync($"api/studente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var stud = JsonSerializer.Deserialize<Studente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(stud);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Studente model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/studente", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"api/studente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var stud = JsonSerializer.Deserialize<Studente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(stud);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Studente model)
        {
            if (id != model.Id) return BadRequest();

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/studente/{id}", content);
            if (res.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var res = await _client.GetAsync($"api/studente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var stud = JsonSerializer.Deserialize<Studente>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(stud);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _client.DeleteAsync($"api/studente/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddCorsi(int id)
        {
            var studente = await _client.GetFromJsonAsync<Studente>($"api/studente/{id}");
            var corsi = await _client.GetFromJsonAsync<List<Corso>>("api/corso");
            ViewBag.Corsi = corsi;
            return View(studente);
        }

        [HttpPost]
        public async Task<IActionResult> AddCorsi(int studenteId, int corsoId)
        {
            await _client.PostAsync($"api/studente/{studenteId}/corsi/{corsoId}", null);
            return RedirectToAction(nameof(Details), new { id = studenteId });
        }

        public async Task<IActionResult> RemoveCorso(int studenteId, int corsoId)
        {
            await _client.DeleteAsync($"api/studente/{studenteId}/corsi/{corsoId}");
            return RedirectToAction(nameof(Details), new { id = studenteId });
        }

    }
}
