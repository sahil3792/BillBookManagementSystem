using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesSummaryController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SalesSummaryController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet("GetSalesSummary")]
        public IActionResult GetSalesSummary()
        {
            var data = db.salessummary.FromSqlRaw("EXEC GetSalesSummary").ToList();
            return Ok(data);
        }

        [Route("GetParty")]
        [HttpGet]
        public IActionResult GetPartyDropdown()
        {
            var data = db.party.FromSqlRaw("exec Fetchallparty");
            return Ok(data);
        }


        [Route("GetStatus")]
        [HttpGet]
        public IActionResult GetStatusDropdown()
        {
            var data = db.status.FromSqlRaw("exec FetchAllStatus");
            return Ok(data);
        }


        [HttpGet("GetSalesById/{partyId:int}")]
        public IActionResult GetSalesById(int partyId)
        {
            var salesSummary = db.salessummary
                .FromSqlRaw("EXEC GetSalesSummaryById @PartyId = {0}", partyId)
                .ToList();

            if (!salesSummary.Any())
            {
                return NotFound("No sales data found for the given Party ID.");
            }

            return Ok(salesSummary);
        }

        [HttpGet("GetSalesByStatus/{invoiceStatus}")]
        public IActionResult GetSalesByStatus(string invoiceStatus)
        {
            if (string.IsNullOrWhiteSpace(invoiceStatus))
            {
                return BadRequest("Invoice status must be provided.");
            }

            var salesSummary = db.salessummary
                .FromSqlRaw("EXEC GetSalesSummaryByStatus @InvoiceStatus = {0}", invoiceStatus)
                .ToList();

            if (!salesSummary.Any())
            {
                return NotFound("No sales data found for the given Invoice Status.");
            }

            return Ok(salesSummary);
        }



        [HttpGet("GetAllParties")]
        public IActionResult GetAllParties()
        {
            var parties = db.party.ToList();
            return Ok(parties);
        }

        [HttpGet("GetSalesByPartyId/{partyId:int}")]
        public IActionResult GetSalesByPartyId(int partyId)
        {
            var salesSummary = db.salessummary
                .FromSqlRaw("EXEC GetSalesSummaryById @PartyId = {0}", partyId)
                .ToList();

            if (!salesSummary.Any())
            {
                return NotFound("No sales data found for the given Party ID.");
            }

            return Ok(salesSummary);
        }
    }
}
