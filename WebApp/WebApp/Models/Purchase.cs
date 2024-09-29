using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseOrderId { get; set; }
        public string InvoiceDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string ValidTill { get; set; }
        public long CurrentStock { get; set; }
        public long PurchaseQuantity { get; set; }
    }
}
