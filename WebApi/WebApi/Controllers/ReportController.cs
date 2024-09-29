using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using WebApi.Data;
using WebApi.Models;
using System.Linq;
using HtmlAgilityPack;
using OfficeOpenXml;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System;
//using DinkToPdf;
//using DinkToPdf.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        //private readonly IConverter _converter;
        //private readonly ILogger<ReportController> _logger;  
        public ReportController(ApplicationDbContext db)
        {
            this.db = db;
            //_converter = converter;
            //_logger = logger;
        }

        [Route("PartywiseOutstanding/{categoryid}")]
        [HttpGet] 
        public IActionResult PartywiseOutstanding(int categoryid)
        {
            Console.WriteLine($"Received request for category id: {categoryid}");
            try
            {
                var data = db.party.FromSqlRaw("EXEC Fetchallpartydefaultcategorydate @partycategory", new SqlParameter("@partycategory", categoryid)).ToList();

                
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("GetPartyCategories")]
        [HttpGet]
        public IActionResult GetPartyCategories()
        {
            var categories = db.PartyCategories.FromSqlRaw("exec FetchthePartyCategory");
            return Ok(categories);
        }

        //ItemReportByParty
        [Route("ItemReportByParty/{id}")]
        [HttpGet]
        public IActionResult ItemReportByParty(int id)
        {
            Console.WriteLine($"Received request for category id: {id}");
            try
            {
                var data = db.itemReportbyParties.FromSqlRaw($"EXEC ItemReportproc @partycategory", new SqlParameter("@partycategory", id)).ToList();
                if (data == null || data.Count == 0)
                {
                    Console.WriteLine("No data returned from database.");
                    return NotFound("No parties found.");
                }
                Console.WriteLine($"Returning {data.Count} parties.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("ItemReportByPartyName/{id}")]
        [HttpGet]
        public IActionResult ItemReportByPartyName(int id)
        {
            Console.WriteLine($"Received request for category id: {id}");
            try
            {
                var data = db.itemReportbyParties.FromSqlRaw($"EXEC ItemReportprocbyPartyname @partyname", new SqlParameter("@partyname", id)).ToList();
                if (data == null || data.Count == 0)
                {
                    Console.WriteLine("No data returned from database.");
                    return NotFound("No parties found.");
                }
                Console.WriteLine($"Returning {data.Count} parties.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [Route("GetPartyCategoriesforItem")]
        [HttpGet]
        public IActionResult GetPartyCategoriesforItem()
        {
            var categories = db.PartyCategories.FromSqlRaw("exec FetchthePartyCategory").ToList();
            return Ok(categories);
        }

        [Route("GetPartyNameforItem")]
        [HttpGet]
        public IActionResult GetPartyName()
        {
            var partyname = db.partynames.FromSqlRaw("exec GetPartyName").ToList();
            return Ok(partyname);
        }

        //SalesDayBook
        [Route("SalesDaybookProcdefault")]
        [HttpGet]
        public IActionResult SalesDayBookDefault()
        {
            var data = db.salesViewModel.FromSqlRaw($"exec SalesDaybookProcdefault").ToList();
            return Ok(data);
        }

        //PurchaseViewModel
        [Route("PurchaseDaybookProcdefault")]
        [HttpGet]
        public IActionResult PurchaseDaybookProcdefault()
        {
            var data = db.purchasesViewModel.FromSqlRaw($"exec PurchaseDaybookProcdefault").ToList();
            return Ok(data);
        }

        //[Route("GetInvoiceDates")]
        //[HttpGet]
        //public IActionResult GetInvoiceDates()
        //{
        //    var invoiceDates = db.sales.Select(s => s.InvoiceDate).Distinct().ToList(); 
        //    return Ok(invoiceDates);
        //}

        //[Route("GetInvoiceDatesSales")]
        //[HttpGet]
        //public IActionResult GetInvoiceDates(string filterType)
        //{
        //    DateTime today = DateTime.Today;
        //    DateTime startDate, endDate;

        //    switch (filterType.ToLower())
        //    {
        //        case "day":
        //            startDate = endDate = today;
        //            break;
        //        case "week":
        //            startDate = today.AddDays(-(int)today.DayOfWeek);
        //            endDate = startDate.AddDays(6);
        //            break;
        //        case "month":
        //            startDate = new DateTime(today.Year, today.Month, 1);
        //            endDate = startDate.AddMonths(1).AddDays(-1);
        //            break;
        //        case "quarter":
        //            int quarter = (today.Month - 1) / 3 + 1;
        //            startDate = new DateTime(today.Year, (quarter - 1) * 3 + 1, 1);
        //            endDate = startDate.AddMonths(3).AddDays(-1);
        //            break;
        //        case "year":
        //            startDate = new DateTime(today.Year, 1, 1);
        //            endDate = new DateTime(today.Year, 12, 31);
        //            break;
        //        default:
        //            return BadRequest("Invalid filter type");
        //    }
        //    var invoiceDates = db.sales
        //        .Select(s => s.InvoiceDate)
        //        .Distinct()
        //        .AsEnumerable() 
        //        .Where(invoiceDateString => DateTime.TryParse(invoiceDateString, out DateTime invoiceDate) &&
        //                             invoiceDate >= startDate && invoiceDate <= endDate).ToList();

        //    return Ok(invoiceDates);
        //}

        //3

        //[Route("GetPurchaseInvoiceDates")]
        //[HttpGet]
        //public IActionResult GetPurchaseInvoiceDates(string filterType)
        //{
        //    DateTime today = DateTime.Today;
        //    DateTime startDate, endDate;

        //    switch (filterType.ToLower())
        //    {
        //        case "day":
        //            startDate = today;
        //            endDate = today;
        //            break;
        //        case "week":
        //            startDate = today.AddDays(-(int)today.DayOfWeek);
        //            endDate = startDate.AddDays(6);
        //            break;
        //        case "month":
        //            startDate = new DateTime(today.Year, today.Month, 1);
        //            endDate = startDate.AddMonths(1).AddDays(-1);
        //            break;
        //        case "quarter":
        //            int quarter = (today.Month - 1) / 3 + 1;
        //            startDate = new DateTime(today.Year, (quarter - 1) * 3 + 1, 1);
        //            endDate = startDate.AddMonths(3).AddDays(-1);
        //            break;
        //        case "year":
        //            startDate = new DateTime(today.Year, 1, 1);
        //            endDate = new DateTime(today.Year, 12, 31);
        //            break;
        //        default:
        //            return BadRequest("Invalid filter type");
        //    }

        //    var invoiceDates = db.purchases
        //        .Select(p => p.InvoiceDate)
        //        .Distinct()
        //        .AsEnumerable() 
        //        .Where(invoiceDateString => DateTime.TryParse(invoiceDateString, out DateTime invoiceDate) &&
        //                             invoiceDate >= startDate && invoiceDate <= endDate).ToList();

        //    return Ok(invoiceDates);
        //}

        //[Route("ItemReportByParty")]
        //[HttpGet]
        //public IActionResult ItemReportByParty(int BillTo)
        //{
        //    var data = db.sales.FromSql($"exec ItemReportByPartyProc {BillTo}").ToList();
        //    return Ok(data);
        //}

        //[HttpGet("downloadpdfparty")]
        //public IActionResult DownloadPDF()
        //{
        //    var items = db.party.ToList(); // Fetch all items from the database

        //    // Create HTML content for the PDF
        //    var htmlContent = new StringBuilder();
        //    htmlContent.Append("<h1>Party Wise Outstanding</h1>");
        //    htmlContent.Append("<table border='1'><tr><th>Party Name</th><th>Party Category</th><th>Phone Number</th><th>Closing Balance</th></tr>");

        //    foreach (var item in items)
        //    {
        //        htmlContent.Append($"<tr><td>{item.PartyName}</td><td>{item.PartyCategory}</td><td>{item.PhoneNumber}</td><td>{item.OpeningBalance}</td></tr>");
        //    }
        //    htmlContent.Append("</table>");

        //    // Configure PDF generation
        //    var pdfDoc = new HtmlToPdfDocument
        //    {
        //        GlobalSettings = {
        //    ColorMode = ColorMode.Color,
        //    Orientation = Orientation.Portrait,
        //    PaperSize = PaperKind.A4,
        //},
        //        Objects = {
        //    new ObjectSettings {
        //        PagesCount = true,
        //        HtmlContent = htmlContent.ToString(),
        //        WebSettings = { DefaultEncoding = "utf-8" }
        //    }
        //}
        //    };

        //    var file = _converter.Convert(pdfDoc);
        //    return File(file, "application/pdf", "PartywiseOutstanding.pdf");
        //}

        //[HttpGet("downloadpdf")]
        //public IActionResult DownloadPDF()
        //{
        //    var items = db.party.ToList(); // Fetch all items from the database

        //    // Create HTML content for the PDF
        //    var htmlContent = new StringBuilder();
        //    htmlContent.Append("<h1>Party</h1>");
        //    htmlContent.Append("<table border='1'><tr><th>Party Name</th><th>Party Category</th><th>Phone Number</th><th>Opening Balance</th></tr>");

        //    foreach (var item in items)
        //    {
        //        htmlContent.Append($"<tr><td>{item.PartyName}</td><td>{item.PartyCategory}</td><td>{item.PhoneNumber}</td><td>{item.OpeningBalance}</td></tr>");
        //    }
        //    htmlContent.Append("</table>");

        //    // Configure PDF generation
        //    var pdfDoc = new HtmlToPdfDocument
        //    {
        //        GlobalSettings = {
        //        //ColorMode = ColorMode.Color,
        //        Orientation = Orientation.Portrait,
        //        //PaperSize = PaperKind.A4,
        //},
        //        Objects = {
        //    new ObjectSettings {
        //        PagesCount = true,
        //        HtmlContent = htmlContent.ToString(),
        //        WebSettings = { DefaultEncoding = "utf-8" }
        //    }
        //}
        //    };

        //    var file = _converter.Convert(pdfDoc);
        //    return File(file, "application/pdf", "Report.pdf");
        //}

        //[HttpGet("downloadexcel")]
        //public IActionResult DownloadExcel()
        //{
        //    var items = db.party.ToList(); // Fetch all items from the database

        //    using (var package = new ExcelPackage())
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("Party");

        //        // Add headers
        //        worksheet.Cells[1, 1].Value = "Party Name";
        //        worksheet.Cells[1, 2].Value = "Party Category";
        //        worksheet.Cells[1, 3].Value = "Phone Number";
        //        worksheet.Cells[1, 4].Value = "Opening Balance";

        //        // Add data
        //        int row = 2;
        //        foreach (var item in items)
        //        {
        //            worksheet.Cells[row, 1].Value = item.PartyName;
        //            worksheet.Cells[row, 2].Value = item.PartyCategory;
        //            worksheet.Cells[row, 3].Value = item.PhoneNumber;
        //            worksheet.Cells[row, 4].Value = item.OpeningBalance;
        //            row++;
        //        }

        //        var file = package.GetAsByteArray();
        //        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        //    }
        //}

    }
}
