using InvoiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {

        HttpClient client;
         public DashboardController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyErrors) =>
            { return true; };
            client = new HttpClient(clientHandler);

        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddSalesInvoice([FromBody] SalesInvoice invoice)
        {
            // Use the individual URL for adding purchase invoice
            string url = "https://localhost:7254/api/Adding/AddSalesInvoice";
            var jsonInvoice = JsonConvert.SerializeObject(invoice);
            var content = new StringContent(jsonInvoice, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return Json("Success");  // Return success message
            }
            return Json("Error");  // Return error message
        }
    }
}
