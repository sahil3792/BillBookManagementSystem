using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        HttpClient client;
        public DashboardController()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Sales> sale = new List<Sales>();
            string url = "https://localhost:7254/api/Report/GetSalesGraph";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Sales>>(jsondata);
                if (obj != null)
                {
                    sale = obj;
                }
                var salesData = sale;

                // Get the current date
                var today = DateTime.Today;

                // Filter sales for the last 7 days
                var last7DaysSales = salesData.Where(s => s.invoiceDate >= today.AddDays(-7) && s.invoiceDate <= today).ToList();

                // Calculate total sales amount for the last 7 days
                var totalAmountLast7Days = last7DaysSales.Sum(s => s.invoiceAmount);

                // Count the number of unique InvoiceIds in the last 7 days
                var totalInvoicesLast7Days = last7DaysSales.Select(s => s.invoiceId).Distinct().Count();

                // Group by Day of the Week (Monday to Sunday)
                var weeklySales = Enumerable.Range(1, 7)
                    .Select(day => new
                    {
                        DayOfWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((System.DayOfWeek)(day % 7)),
                        invoiceAmount = salesData
                            .Where(s => (int)s.invoiceDate.DayOfWeek == day % 7) // Matches day of the week (Sunday=0, Monday=1, etc.)
                            .Sum(s => s.invoiceAmount)
                    })
                    .ToList();

                // Pass both weekly sales and total sales to the view
                //var last7DaysSales = salesData.Where(s => s.InvoiceDate >= today.AddDays(-7) && s.InvoiceDate <= today).ToList();
                ViewBag.TotalAmountLast7Days = totalAmountLast7Days;
                ViewBag.TotalInvoicesLast7Days = totalInvoicesLast7Days;

                //return View(weeklySales);

                return View(weeklySales);
            }
            return View();
        }
    }
}
