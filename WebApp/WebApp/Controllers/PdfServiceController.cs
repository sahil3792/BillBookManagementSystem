//using DinkToPdf.Contracts;
//using DinkToPdf;
//using Microsoft.AspNetCore.Mvc;
//using WebApp.Models;
//using Microsoft.EntityFrameworkCore;

//namespace WebApp.Controllers
//{
//    public class PdfServiceController : Controller
//    {
//        private readonly IConverter _converter;
//        private readonly ILogger<ReportController> _logger;


//        public PdfServiceController(IConverter converter, ILogger<ReportController> logger)
//        {
//            _converter = converter;
//            _logger = logger;
//        }
//        public byte[] GeneratePdf(List<Party> party)
//        {
//            var htmlContent = "<html><body><h1>Sales Report</h1><table>";
//            htmlContent += "<tr><th>ID</th><th>Party Name</th><th>Party Category</th><th></th>Phone Number<th>Opening Balance</th></tr>";
//            foreach (var p in party)
//            {
//                htmlContent += $"<tr><td>{p.PartyName}</td><td>{p.PartyCategory}</td><td>{p.PhoneNumber}</td><td>{p.OpeningBalance}</td></tr>";
//            }
//            htmlContent += "</table></body></html>";

//            if (party == null || !party.Any())
//            {
//                Console.WriteLine("No sales found.");
//            }
//            var doc = CreateHtmlToPdfDocument(htmlContent);
//            return _converter.Convert(doc);
//        }

//        public byte[] GeneratePdf(List<PurchaseViewModel> purchases)
//        {
//            var htmlContent = "<html><body><h1>Purchase Report</h1><table>";
//            htmlContent += "<tr><th>ID</th><th>Date</th><th>Party Name</th><th>Purchase Price</th><th>GSTIN Number</th></tr>";
//            foreach (var purchase in purchases)
//            {
//                htmlContent += $"<tr><td>{purchase.PurchaseOrderId}</td><td>{purchase.InvoiceDate}</td><td>{purchase.PartyName}</td><td>{purchase.PurchaseAmount}</td><td>{purchase.GSTINNumber}</td></tr>";
//            }
//            htmlContent += "</table></body></html>";
//            if (purchases == null || !purchases.Any())
//            {
//                Console.WriteLine("No purchases found.");
//            }

//            var doc = CreateHtmlToPdfDocument(htmlContent);
//            return _converter.Convert(doc);
//        }

//        private HtmlToPdfDocument CreateHtmlToPdfDocument(string htmlContent)
//        {
//            return new HtmlToPdfDocument()
//            {
//                GlobalSettings = {
//                    ColorMode = ColorMode.Color,
//                    Orientation = Orientation.Portrait,
//                    PaperSize = PaperKind.A4,
//                },
//                Objects = {
//                    new ObjectSettings() {
//                        HtmlContent = htmlContent,
//                        WebSettings = { DefaultEncoding = "utf-8" }
//                    }
//                }
//            };
//        }
//    }
//}
