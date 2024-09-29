using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class InvoicedItem
    {
        [Key]
        public int id { get; set; }
        public long SalesId { get; set; }
        public long InvoiceId { get; set; }
        public long Items { get; set; }
        public decimal Quantity { get; set; }
    }
}
