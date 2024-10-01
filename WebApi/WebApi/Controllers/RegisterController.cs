using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApi.Data;

using WebApi.Modules;

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
       
        public IActionResult RegisterView(Register r)
        {
           var data= db.Database.ExecuteSqlRaw($"Exec InsertRegister '{r.BusinessName}','{r.BusinessRegistrationType}','{r.BusinessType}','{r.IndustryType}','{r.GSTRegistered}','{r.GSTNumber}',{r.ContactNumber}");
            return Ok(data);
        }



    }
}
