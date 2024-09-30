using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PartyController : Controller
    {
        private readonly ApplicationDbContext db;
        public PartyController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [Route("GetAllParties")]
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var data = db.party.ToList();
                
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing your request. {ex.Message}");
            }

        }
        [Route("AddParties")]
        [HttpPost]
        public IActionResult AddParty(Party p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.party.Add(p);
                    db.SaveChanges();
                    return Ok("Parties Added Successfully");
                }
                return BadRequest("Invalid Data Provided to Add Parties");
            }
            catch (Exception ex)
            {
                return BadRequest($"Parties Not added {ex.Message}");
            }
        }
        [Route("SearchByCategory/{categories}")]
        [HttpGet]
        public IActionResult Search(string categories)
        {
            try
            {
                var data = db.party.Where(x => categories.Contains(x.PartyName) || categories.Contains(x.PartyName)).ToList();
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Data not available for the selected Categories");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing your request. {ex.Message}");
            }

        }

    }
}
