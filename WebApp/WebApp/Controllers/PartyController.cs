using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PartyController : Controller
    {
        HttpClient client;
        public PartyController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddParties()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddParties(Party p)
        {
            string url = "https://localhost:7254/api/Party/AddParties";
            var jsondata = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["AddPartiesmsg"] = "Parties Careated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetAllParties()
        {
            List<Party> party = new List<Party>();
            string url = "https://localhost:7254/api/Party/GetAllParties";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Party>>(jsondata);
                if (obj != null)
                {
                    party = obj;
                }
            }
            return View(party);
        }

        public IActionResult GetParties()
        {
            List<Party> party = new List<Party>();
            string url = "https://localhost:7254/api/Party/GetAllParties";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Party>>(jsondata);
                if (obj != null)
                {
                    party = obj;
                }
            }
            return Json(new { count = party.Count, parties = party });
        }
        [HttpGet]
        public IActionResult SearchParties(string categories)
        {
            List<Party> party = new List<Party>();
            string url = $"https://localhost:7254/api/Party/SearchByCategory/{categories}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Party>>(jsondata);
                if (obj != null)
                {
                    party = obj;
                }
                return Json(party);
            }
            return Json(new { error = "Error retrieving data." });
        }
    }
}
