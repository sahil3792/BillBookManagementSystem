using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient client;

        public DashboardController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
     
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetDetails()
        {
            
            
            var userEmail = HttpContext.Session.GetString("UserEmail");
            string url = $"https://localhost:7254/api/Register/getdetails/{userEmail}";

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<Businesses>(jsondata);
                
                return Json(obj);
            }
            else
            {
                return View();

            }
            
        }

        
      
    }
}
