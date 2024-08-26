using Microsoft.AspNetCore.Mvc;
using MossadAPI.Models;
using MossadMVC.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MossadMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> Mossad()
        {
            var result = await _httpClient.GetStringAsync($"http://localhost:5059/View/mossad");
            MossadView? mossad = JsonConvert.DeserializeObject<MossadView>(result);
            return View(mossad);
        }

        public async Task<IActionResult> Targets()
        {
            var result = await _httpClient.GetStringAsync($"http://localhost:5059/View/Targets");
            List<TargetView>? targets = JsonConvert.DeserializeObject<List<TargetView>>(result);
            return View(targets);
        }

        public async Task<IActionResult> Agents()
        {
            var result = await _httpClient.GetStringAsync($"http://localhost:5059/View/Agents");
            List<AgentView>? agents = JsonConvert.DeserializeObject<List<AgentView>>(result);
            return View(agents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
