using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {

        private readonly ApplicationDbContext db;

        public SalesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("GetParty")]
        [HttpGet]
        public IActionResult GetPartyDropdown()
        {
            var data = db.party.FromSqlRaw("exec FetchAllPartyForBill");
            return Ok(data);
        }

        [Route("GetBillWiseProfit")]
        [HttpGet]
        public IActionResult GetBillWiseProfit()
        {
            var data = db.billwiseprofit.FromSqlRaw($"exec GetSalesDetails");
            return Ok(data);
        }

        [HttpGet("GetBillByPartyId/{partyId:int}")]
        public IActionResult GetBillByPartyId(int partyId)
        {
            var salesSummary = db.billwiseprofit
                .FromSqlRaw("EXEC GetBillByPartyId @PartyId = {0}", partyId)
                .ToList();

            if (!salesSummary.Any())
            {
                return NotFound("No sales data found for the given Party ID.");
            }

            return Ok(salesSummary);
        }
    }
}
