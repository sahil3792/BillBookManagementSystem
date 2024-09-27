using Microsoft.AspNetCore.Mvc;
using MyBillBook.Models;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace MyBillBook.Controllers
{
    public class PartiesController : Controller
    {
        HttpClient client;
        public PartiesController()
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
        public IActionResult AddParties(Parties p)
        {
            string url = "https://localhost:44312/api/Party/AddParties";
            var jsondata = JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jsondata,Encoding.UTF8,"application/json");
            HttpResponseMessage response=client.PostAsync(url, content).Result;
            if(response.IsSuccessStatusCode)
            {
                TempData["AddPartiesmsg"] = "Parties Careated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
       
        public IActionResult GetAllParties()
        {
            List<Parties> party= new List<Parties>();
            string url = "https://localhost:44312/api/Party/GetAllParties";
            HttpResponseMessage response=client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsondata=response.Content.ReadAsStringAsync().Result;
                var obj=JsonConvert.DeserializeObject<List<Parties>>(jsondata);
                if(obj != null)
                {
                    party = obj;
                }
            }
                return View(party);
        }
        
        public IActionResult GetParties()
        {
            List<Parties> party = new List<Parties>();
            string url = "https://localhost:44312/api/Party/GetAllParties";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Parties>>(jsondata);
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
            List<Parties> party = new List<Parties>();
            string url = $"https://localhost:44312/api/Party/SearchByCategory/{categories}";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Parties>>(jsondata);
                if(obj!=null)
                {
                    party = obj;
                }
                return Json(party);
            }
            return Json(new { error = "Error retrieving data." });
        }
    }
}
