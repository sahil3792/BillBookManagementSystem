using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Business> businesses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Inventories> inventories { get; set; }
        public DbSet<InvoicedItem> invoicedItems { get; set;}
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<Parties> parties { get; set; }
        public DbSet<SalesInvoice> salesInvoices { get; set;}
    }
 }

