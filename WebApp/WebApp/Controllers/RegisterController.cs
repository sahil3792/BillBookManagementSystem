using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


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
        public IActionResult Register(Businesses r)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            
                if (string.IsNullOrWhiteSpace(r.GSTNumber))
                {
                    r.GSTNumber = "Empty";
                }
              // r.GSTNumber = "Empty";
                r.Email = userEmail;
                string url = "https://localhost:7254/api/Register/Register";
                var jsondata = JsonConvert.SerializeObject(r);
                StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Msg"] = "Registed Successfully";
                    return RedirectToAction("Index","Dashboard");
                }
         
            

            return View();

        }

       
      
public async Task<IActionResult> Logout()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Delete all the cookies
        var storedCookies = Request.Cookies.Keys;
        foreach (var cookie in storedCookies)
        {
            Response.Cookies.Delete(cookie);
        }

        // Redirect to the desired action after logout
        return RedirectToAction("Index", "Landingpage");
    }



}
}
