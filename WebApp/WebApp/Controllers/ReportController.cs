using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using System;
using WebApp.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http;


namespace WebApp.Controllers
{
    public class ReportController : Controller
    {
        HttpClient client;
        //private readonly PdfServiceController _pdfService;
        private readonly IConverter _converter;
        //private readonly ILogger<ReportController> _logger;
        public ReportController(IConverter converter)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);

            //_pdfService = new PdfServiceController(converter);
        }

        public IActionResult PartywiseOutstanding()
        {
            return View();
        }
        public IActionResult FetchPartywiseOutstandingData(int categoryid)
        {
            List<Party> party = new List<Party>();
            string url = $"https://localhost:7254/api/Report/PartywiseOutstanding/{categoryid}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                party = JsonConvert.DeserializeObject<List<Party>>(jsondata);
                return Json(party);
            }

            else
            {
                return Json("");
            }
        }
        public  IActionResult GetPartyCategories()
        {
            List<PartyCategory> partiescategory = new List<PartyCategory>();
            string url = "https://localhost:7254/api/Report/GetPartyCategories";
            HttpResponseMessage mes = client.GetAsync(url).Result;
            if(mes.IsSuccessStatusCode)
            {
                var jsondata = mes.Content.ReadAsStringAsync().Result;
                partiescategory = JsonConvert.DeserializeObject<List<PartyCategory>>(jsondata);
                return Json(partiescategory);
            }
            else
            {
                return Json("");
            }
        }

        //ItemReportByParty
        public IActionResult ItemReportByParty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ItemReportByParty(ItemReportByPartyViewModel i)
        {
            return View();
        }
        public IActionResult FetchItemReportByPartyData(int id)
        {
            List<ItemReportbyParty> item = new List<ItemReportbyParty>();
            string url = $"https://localhost:7254/api/Report/ItemReportByParty/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                item = JsonConvert.DeserializeObject<List<ItemReportbyParty>>(jsondata);
                return Json(item);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult GetPartyCategoriesforItem()
        {
            List<PartyCategory> partiescategory = new List<PartyCategory>();
            string url = "https://localhost:7254/api/Report/GetPartyCategories";
            HttpResponseMessage mes = client.GetAsync(url).Result;
            if (mes.IsSuccessStatusCode)
            {
                var jsondata = mes.Content.ReadAsStringAsync().Result;
                partiescategory = JsonConvert.DeserializeObject<List<PartyCategory>>(jsondata);
                return Json(partiescategory);
            }
            else
            {
                return Json("");
            }
        }

        public IActionResult FetchItemReportByPartyName(int id)
        {
            List<ItemReportbyParty> item = new List<ItemReportbyParty>();
            string url = $"https://localhost:7254/api/Report/ItemReportByPartyName/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsondata = response.Content.ReadAsStringAsync().Result;
                item = JsonConvert.DeserializeObject<List<ItemReportbyParty>>(jsondata);
                return Json(item);
            }
            else
            {
                return Json("");
            }

        }

        public IActionResult GetPartyNameforItem()
        {
            List<partynames> partyname = new List<partynames>();
           
            string url= "https://localhost:7254/api/Report/GetPartyNameforItem";
             HttpResponseMessage mes = client.GetAsync(url).Result;
            if (mes.IsSuccessStatusCode)
            {
                var jsondata = mes.Content.ReadAsStringAsync().Result;
                partyname = JsonConvert.DeserializeObject<List<partynames>>(jsondata);
                return Json(partyname);
            }
            else
            {
                return Json("");
            }
        }

        //SalesDaybook
        public async Task<IActionResult> SalesDayBook()
        {
            List<SalesViewModel> sales = new List<SalesViewModel>();
            string url = "https://localhost:7254/api/Report/SalesDaybookProcdefault";
            HttpResponseMessage response = await client.GetAsync(url);
            
                if (response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    sales = JsonConvert.DeserializeObject<List<SalesViewModel>>(jsondata);
                }
            return View(sales);
        }

        //PurchaseDaybook
        public async Task<IActionResult> PurchaseDayBook()
        {
            List<PurchaseViewModel> purchases = new List<PurchaseViewModel>();
            string url = "https://localhost:7254/api/Report/PurchaseDaybookProcdefault";
            HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsondata = await response.Content.ReadAsStringAsync();
                    purchases = JsonConvert.DeserializeObject<List<PurchaseViewModel>>(jsondata);
                }
            return View(purchases);           
        }

        public async Task<IActionResult> Downloadpdf()
        {
            var response = await client.GetAsync("https://localhost:7254/api/Report/downloadpdf");
            if (response.IsSuccessStatusCode)
            {
                var pdf = await response.Content.ReadAsByteArrayAsync();
                return File(pdf, "application/pdf", "Report.pdf");
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DownloadExcel()
        {
            var response = await client.GetAsync("https://localhost:7254/api/Report/downloadexcel");
            if (response.IsSuccessStatusCode)
            {
                var excel = await response.Content.ReadAsByteArrayAsync();
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
