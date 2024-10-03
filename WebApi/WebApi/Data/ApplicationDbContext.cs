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
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<PartyOutsandingViewModel> partyOutsandingViewModels { get; set; }  

        //public DbSet<Businesses> Registers { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<MyStock> MyStocks { get; set; }
      

        public DbSet<Category> Categories { get; set; }

        public DbSet<Parties> Parties { get; set; }

        public DbSet<Businesses> Businesses { get; set; }

        public DbSet<Status> status { get; set; }
        public DbSet<SalesSummaryResult> salessummary { get; set; }
        public DbSet<BillWiseProfit> billwiseprofit { get; set; }

    }
}
