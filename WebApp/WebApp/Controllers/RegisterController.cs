using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        HttpClient client;

        public RegisterController()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clienthandler);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register r)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(r.GSTNumber))
                {
                    r.GSTNumber = "Empty";
                }
               // r.GSTNumber = "Empty";
                string url = "https://localhost:7254/api/Register/Register";
                var jsondata = JsonConvert.SerializeObject(r);
                StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Msg"] = "Registed Successfully";
                    return RedirectToAction("Dashboard/Index");
                }
               
            }
            else
            {
                TempData["Msg"] = "Something Went Wrong please try again later or Contact the system Admin";
                return View();
            }

            return View();

        }
    }
}
