using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ConsumingController : Controller
    {
        HttpClient client;
        public ConsumingController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chin, SslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }
        public IActionResult Index()
        {
            List<SI> sio = new List<SI>();
            string url = "https://localhost:7254/api/Adding/GetAddesSI"; // Adjust the URL to your actual API endpoint
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<SI>>(jsondata);

                if (obj != null)
                {
                    sio = obj;
                }
            }

            return View(sio);
        }
        public IActionResult Index2()
        {
            List<SI> sio = new List<SI>();
            string url = "https://localhost:7254/api/Adding/GetAddesSI"; // Adjust the URL to your actual API endpoint
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<SI>>(jsondata);

                if (obj != null)
                {
                    sio = obj;
                }
            }

            return Json(sio);
        }
        public IActionResult AddSI()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddSI(SI s)
        {
            
            string url2 = "https://localhost:7254/api/Adding/AddSI/";


            var jsondata = JsonConvert.SerializeObject(s);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");

          
            HttpResponseMessage res = client.PostAsync(url2, stringContent).Result;

            if (res.IsSuccessStatusCode)
            {
                
                var responseData = res.Content.ReadAsStringAsync().Result;
                var savedSI = JsonConvert.DeserializeObject<SI>(responseData);


                if (savedSI != null && savedSI.InvoiceID != 0)
                {
                    return RedirectToAction("InvoiceView", new { id = savedSI.InvoiceID });
                }
            }

            return View("AddSI");
        }

        public IActionResult InvoiceView(int id)
        {
            string url = $"https://localhost:7254/api/Adding/GetSIById/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var invoice = JsonConvert.DeserializeObject<SI>(jsondata);

                if (invoice != null)
                {
                    return View(invoice); 
                }
            }

            return View("Error"); 
        }


        public IActionResult GetItem()
        {
            List<Inventory> inventories = new List<Inventory>();
            string url = "https://localhost:7254/api/Adding/GetItem"; 
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Inventory>>(jsondata);

                if (obj != null)
                {
                    inventories = obj;
                }
            }

            return Json(inventories); // Return inventories as JSON to be consumed by the AJAX call
        }

    }
}
