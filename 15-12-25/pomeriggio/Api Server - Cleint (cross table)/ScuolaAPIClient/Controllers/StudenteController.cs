using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ScuolaAPIClient.Controllers
{
    public class StudenteController : Controller
    {
        private readonly HttpClient _client;

        public StudenteController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ScuolaAPI");
        }

        // READ ALL
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Studente");
            var json = await response.Content.ReadAsStringAsync();
            var studenti = JsonSerializer.Deserialize<List<StudenteDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(studenti);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudenteDto s)
        {
            if (!ModelState.IsValid)
                return View(s);

            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("Studente", content);
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _client.GetAsync($"Studente/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();

            var json = await res.Content.ReadAsStringAsync();
            var studente = JsonSerializer.Deserialize<StudenteDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(studente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudenteDto s)
        {
            var json = JsonSerializer.Serialize(s);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PutAsync($"Studente/{id}", content);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Studente/{id}");
            return RedirectToAction(nameof(Index));
        }
    }

}
