using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class InvoicedItem
    {
        [Key]
        public int id { get; set; }
        public int SalesId { get; set; }
        public int InvoiceId { get; set; }
        public int InventoryId { get; set; }
        public decimal Quantity { get; set; }
    }
}
