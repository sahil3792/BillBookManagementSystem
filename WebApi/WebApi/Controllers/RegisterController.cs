using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApi.Data;

using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public RegisterController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("Register")]
        [HttpPost]
       
        public IActionResult RegisterView(Businesses r)
        {
           var data= db.Database.ExecuteSqlRaw($"Exec sp_RegisterBusiness '{r.BusinessName}','{r.BusinessRegistrationType}','{r.BusinessType}','{r.IndustryType}','{r.GSTNumber}','{r.GSTRegistered}','{r.ContactNumber}','{r.Email}'");
            return Ok(data);
        }

        [Route("CheckExist/{email}")]
        [HttpGet]
        public IActionResult CheckExist(string email)
        {
            var data = db.Businesses.Where(x => x.Email == email).SingleOrDefault();
            if (data != null)
            {
                return Ok(1);
            }
            return Ok(0);
        }



    }
}
