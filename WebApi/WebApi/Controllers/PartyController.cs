using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBillBook_Api.Data;
using MyBillBook_Api.Models;


namespace MyBillBook_Api.Controllers
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
                var data = db.Party.ToList();
                if (data.IsNullOrEmpty())
                {
                    return BadRequest("Data is not avialable");
                }
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest($"An error occurred while processing your request. {ex.Message}");
            }
            
        }
        [Route("AddParties")]
        [HttpPost]
        public IActionResult AddParty(Parties p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Party.Add(p);
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
                var data = db.Party.Where(x => categories.Contains(x.PartyCategory)||categories.Contains(x.PartyName)).ToList();
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Data not available for the selected Categories");
            }
            catch(Exception ex)
            {
                return BadRequest($"An error occurred while processing your request. {ex.Message}");
            }
           
        }

    }
}
