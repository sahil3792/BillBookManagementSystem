using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<InvoicedItem> invoicedItems { get; set; }
        public DbSet<Invoices> invoices { get; set; }
        public DbSet<Party> party { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<Sales> sales { get; set; }
        public DbSet<SalesViewModel>   salesViewModel { get; set; }
        public DbSet<PurchaseViewModel> purchasesViewModel { get; set; }
        public DbSet<ItemReportbyParty> itemReportbyParties { get; set; }
        public DbSet<partynames> partynames { get; set; }
        public DbSet<PartyCategory> PartyCategories { get; set; }
        
    }
}
