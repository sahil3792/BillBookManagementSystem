using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;
using WebApi.Modules;

namespace WebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Register> Registers { get; set; }
    }
}
