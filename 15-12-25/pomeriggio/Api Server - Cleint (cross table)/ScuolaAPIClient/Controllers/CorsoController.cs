using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ScuolaAPIClient.Controllers
{
    public class CorsoController : Controller
    {
        private readonly HttpClient _client;

        public CorsoController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ScuolaAPI");
        }

        // READ ALL
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Corso");
            var json = await response.Content.ReadAsStringAsync();
            var corsi = JsonSerializer.Deserialize<List<CorsoDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(corsi);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CorsoDto s)
        {
            if (!ModelState.IsValid)
                return View(s);

            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("Corso", content);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"Corso/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var Corso = JsonSerializer.Deserialize<CorsoDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(Corso);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CorsoDto s)
        {
            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PutAsync($"Corso/{id}", content);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Corso/{id}");
            return RedirectToAction(nameof(Index));
        }
    }

}