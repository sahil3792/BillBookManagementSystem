using Microsoft.EntityFrameworkCore;
using MyBillBook_Api.Models;

namespace MyBillBook_Api.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
        public DbSet<Parties> Party {  get; set; }
    }
}
