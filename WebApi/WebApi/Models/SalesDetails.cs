using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SalesDetails
    {
        [Key]
        // public int Id { get; set; }
        public int BillTo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public int InventoryItemid { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Profit { get; set; }
    }
}
