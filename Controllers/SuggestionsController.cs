using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

using MossadMVC.Models;

namespace MossadMVC.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly HttpClient _httpClient;
        public SuggestionsController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetStringAsync("http://localhost:5059/View/suggestionsMissions");
            List<SuggestionView>? suggestions = JsonConvert.DeserializeObject<List<SuggestionView>>(result);
            return View(suggestions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _httpClient.GetStringAsync($"http://localhost:5059/View/suggestionsMissions/{id}");
            if (result == null) { return RedirectToAction("Index"); }
            SuggestionView? suggestions = JsonConvert.DeserializeObject<SuggestionView>(result);
            return View(suggestions);
        }

        public async Task<IActionResult> PutStatus(int id)
        {
            _httpClient.PutAsJsonAsync($"http://localhost:5059/Missions/{id}", "{ “status”: “Assigned” }");
            return RedirectToAction("Index");
        }
    }
}
