using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ScuolaAPIClient.Controllers
{
    public class ProfessoreController : Controller
    {
        private readonly HttpClient _client;

        public ProfessoreController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ScuolaAPI");
        }

        // READ ALL
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Professore");
            var json = await response.Content.ReadAsStringAsync();
            var professori = JsonSerializer.Deserialize<List<ProfessoreDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(professori);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessoreDto s)
        {
            if (!ModelState.IsValid)
                return View(s);

            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("Professore", content);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"Professore/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var Professore = JsonSerializer.Deserialize<ProfessoreDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(Professore);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProfessoreDto s)
        {
            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PutAsync($"Professore/{id}", content);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Professore/{id}");
            return RedirectToAction(nameof(Index));
        }
    }

}