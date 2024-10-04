using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddingController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public AddingController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("AddSI")]
        [HttpPost]
        public IActionResult CreateSI(SI s)
        {
            var asi = db.Database.ExecuteSqlRaw($"exec addsi '{s.invoiceDate}','{s.InvoiceID}','{s.partyName}','{s.shippingAddress}','{s.dueDate}','{s.Amount}','{s.Status}','{s.paymentMode}','{s.invoicepdf}'");
            return Ok(asi);
        }
        [Route("GetAddesSI")]
        [HttpGet]
        public IActionResult FetchAddedSI()
        {
            var sio = db.SI.FromSqlRaw("exec getaddedsi");
            return Ok(sio);
        }

        [Route("GetSIById/{id}")]
        [HttpGet]
        public IActionResult GetSIById(int id)
        {
            // Use a stored procedure or direct SQL query to fetch the sales invoice by InvoiceID
            var invoice = db.SI.FromSqlRaw($"exec GetSIById @p0",id);

            if (invoice == null)
            {
                return NotFound($"Invoice with ID {id} not found.");
            }

            return Ok(invoice);  // Return the invoice data as JSON
        }


        [Route("GetSI")]
        [HttpGet]
        public IActionResult GetFSI()
        {
            var siop = db.SIO.FromSqlRaw("exec fetchsi");
            return Ok(siop);
        }


        [Route("AddBusiness")]
        [HttpPost]
        public IActionResult AddBusiness(Businesses b)
        {

            var result = db.Database.ExecuteSqlRaw(
               $"EXEC InsertBusiness '{b.BusinessName}','{b.BusinessRegistrationType}','{b.BusinessType}','{b.IndustryType}','{b.GSTRegistered}','{b.ContactNumber}'");
            return Ok(result);
        }


            [Route("GetBusiness")]
        [HttpGet]
        public IActionResult getBusinesses()
        {
           var data=db.Businesses.FromSqlRaw("Exec getbusiness").ToList();
            return Ok(data);
        }
        [Route("AddParties")]
        [HttpPost]
        public IActionResult AddParties(Parties p)
        {
            var result = db.Database.ExecuteSqlRaw(
               $"EXEC InsertParty '{p.PartyName}', '{p.Email}', {p.PhoneNumber}, {p.OpeningBalance}, '{p.GSTINNumber}', '{p.PanCardNumber}', '{p.PartyType}', '{p.PartyCategory}', '{p.BillingAddress}', '{p.ShippingAddress}', {p.CreditPeriod}, {p.CreditLimit}");

            return Ok("Party added successfully");
        }

        [Route("GetParty")]
        [HttpGet]
        public IActionResult getParties() 
        {
            var part= db.Parties.FromSqlRaw("Exec getparty");
            return Ok(part);
        }
        [Route("AddItem")]
        [HttpPost]
        public IActionResult AddItems(Inventory i)
        {
         
            var result = db.Database.ExecuteSqlRaw(
                $"EXEC InsertInventory '{i.ItemType}', {i.CategoryID}, {i.OpeningStock}, '{i.ItemName}', {i.SalesPrice}, '{i.GSTTaxRate}', '{i.MeasuringUnit}', {i.OpeningStock}, {i.PurchasePrice}, '{i.ItemCode}', '{i.HSNCode}', '{i.Description}', '{i.Image}', {i.BusinessId}"
            );

            return Ok("Item added successfully");
        }

        [Route("GetItem")]
        [HttpGet]
        public IActionResult GetItems()
        {
          
            var items = db.inventories.FromSqlRaw("EXEC getitems").ToList();
            return Ok(items);
        }


        [Route("Addcategory")]
        [HttpPost]
        public IActionResult Addcategories(Category c)
        {
            var data = db.Database.ExecuteSqlRaw($"Exec InsertCategory '{c.CategoryName}'");
            db.SaveChanges();
            return Ok(" added successfully");
        }
        [Route("GetCategory")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var ct = db.ItemCategories.FromSqlRaw("Exec getcategory");
            return Ok(ct);
        }
        [Route("AddInvoicedItem")]
        [HttpPost]
        public IActionResult AddInvoItems(InvoicedItem it)
        {
            var result = db.Database.ExecuteSqlRaw(
                $"EXEC InsertInvoicedItem {it.SalesId}, {it.InventoryId}"
            );

            return Ok("Invoiced item added successfully");
        }

        [Route("GetInvoicedItems")]
        [HttpGet]
        public IActionResult GetInvoItems()
        {
            var invoicedItems = db.invoicedItems.FromSqlRaw("EXEC getinvoiceditems").ToList();
            return Ok(invoicedItems);
        }
        [Route("AddInvoices")]
        [HttpPost]
        public IActionResult AddInvoice(Invoices i)
        {
            var result = db.Database.ExecuteSqlRaw(
                $"EXEC InsertInvoice '{i.Status}'"
            );

            return Ok("Invoice added successfully");
        }

        [Route("GetInvoices")]
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = db.invoices.FromSqlRaw("EXEC getinvoiceitems").ToList();
            return Ok(invoices);
        }

        [Route("AddSalesInvoice")]
        [HttpPost]
        public IActionResult AddSalesInvoice(Sales si)
        {
            var result = db.Database.ExecuteSqlRaw(
                $"EXEC InsertSalesInvoice  {si.BillTo}, {si.InvoicedItemsId}, {si.InvoiceId}, '{si.InvoiceDate}', '{si.InvoiceDate}', {si.SalesQuantity}, {si.SalesQuantity}"
            );

            return Ok("Sales invoice added successfully");
        }

        [Route("GetSalesInvoices")]
        [HttpGet]
        public IActionResult GetSalesInvoices()
        {
            var salesInvoices = db.sales.FromSqlRaw("EXEC getsalesinvoices").ToList();
            return Ok(salesInvoices);
        }

    }
}
