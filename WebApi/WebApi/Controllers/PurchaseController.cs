using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly ApplicationDbContext db;
        public PurchaseController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        [Route("NewPurchase")]
        public IActionResult NewPurchase([FromBody] PurchaseRequest purchaseRequest)
        {
            //Creating PurchaseOrder in PurchaseOrders table
            db.PurchaseOrders.Add(purchaseRequest.PurchaseOrder);
            db.SaveChanges();
            //Inserting Stocks in MyStocks table with PurchaseOrderId
            foreach (var stock in purchaseRequest.Stocks)
            {
                stock.PurchaseOrderId = purchaseRequest.PurchaseOrder.PurchaseOrderId;
            }
            // Add stocks using AddRange
            db.MyStocks.AddRange(purchaseRequest.Stocks);
            // Save changes to the database again to save stocks
            db.SaveChanges();
            return Ok();
        }

        //Getting categories for Categories Dropdown

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var data = db.Categories.ToList();
            return Ok(data);
        }

        // Getting Items From Global Inventory as per selected category

        [HttpGet]
        [Route("GetItemsByCategoryId/{categoryId}")]
        public IActionResult GetItemsByCategoryId(int categoryId)
        {
            var items = db.inventories.Where(c => c.CategoryID == categoryId).ToList();
            return Ok(items);
        }

        //Getting parties for party dropdwon
        [HttpGet]
        [Route("GetAllParties")]
        public IActionResult GetAllParties()
        {
            var parties = db.Parties.ToList();
            return Ok(parties);
        }

        //Api working , fetching at consuming side is remaining for dynamically reflecting quantity

        [HttpGet]
        [Route("GetPartyStocksByBusinessId/{businessId}/{purchaseOrderId}")]
        public IActionResult GetPartyStocksByBusinessId(int businessId, int purchaseOrderId)
        {
            var mystock = db.MyStocks.FromSqlRaw("EXEC GetMyStocks @BusinessId = {0}, @PurchaseOrderId = {1}", businessId, purchaseOrderId).ToList();
            return Ok(mystock);
        }

        [HttpGet]
        [Route("GetAllPurchaseOrders")]
        public IActionResult GetAllPurchaseOrders()
        {
            var Allpurchaseorders = db.PurchaseOrders.ToList();
            return Ok(Allpurchaseorders);
        }


        [HttpGet]
        [Route("GetAllPurchaseOrderById")]
        public IActionResult GetAllPurchaseOrderById(int PID)
        {
            var purchaseRequest = new PurchaseRequest();
            //using .AsEnumerable() cause its showing some composable error , tried multiple ways 
            purchaseRequest.PurchaseOrder = db.PurchaseOrders
                .FromSqlRaw("EXEC FetchPOWithID @PurchaseOrderId = {0}", PID)
                .AsEnumerable().SingleOrDefault();

            purchaseRequest.Stocks = db.MyStocks
                .FromSqlRaw("EXEC FetchStocksWithID @PurchaseOrderId = {0}", PID)
                .AsEnumerable().ToList();

            return Ok(purchaseRequest);
        }




        [HttpPost]
        [Route("SubmitPayment")]
        public async Task<IActionResult> SubmitPayment([FromBody] PaymentRequest paymentRequest)
        {
            if (paymentRequest == null || string.IsNullOrEmpty(paymentRequest.PaymentMethod))
            {
                return BadRequest("Invalid payment request.");
            }

            var purchaseOrder = await db.PurchaseOrders.FindAsync(paymentRequest.PurchaseOrderId);
            if (purchaseOrder == null)
            {
                return NotFound("Purchase order not found.");
            }

            // Update the status of the purchase order
            purchaseOrder.Status = "Paid";
            await db.SaveChangesAsync(); // Save changes to the database

            return Ok(new { Message = "Payment processed successfully." });
        }
    }
}
