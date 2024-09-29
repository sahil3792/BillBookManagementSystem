using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Sales
    {
        [Key]
        public int id { get; set; }
        public int BillTo { get; set; }
        public int ShipTo { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public int InvoicedItemsId { get; set; }
        public decimal SalesQuantity { get; set; }
        
    }
}
