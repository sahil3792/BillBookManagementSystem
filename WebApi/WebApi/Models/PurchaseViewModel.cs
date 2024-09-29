using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class PurchaseViewModel
    {
        [Key]
        public int PurchaseOrderId { get; set; } // Invoice ID
        public string InvoiceDate { get; set; }
        public decimal PurchaseAmount { get; set; } // Renamed from PurchaseAmount
        public string ValidTill { get; set; }
        public string PartyName { get; set; } // Added PartyName
        public string GSTINNumber { get; set; } // Added GSTIN Number
    }
}
