using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Sales
    {
        [Key]
        public int id { get; set; }
        public long BillTo { get; set; }
        public long ShipTo { get; set; }
        public long InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public long ItemId { get; set; }
        public long SalesQuantity { get; set; }
        //public string PartyName { get; set; } // Add this property if not already present
        //public decimal SalesPrice { get; set; } // Add this property if not already present
        //public string GSTINNumber { get; set; } // Add this property if not already present
        //public long Status { get; set; }

    }
}
