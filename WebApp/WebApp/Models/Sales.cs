using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Sales
    {
        [Key]
        public int id { get; set; }
        public string? billTo { get; set; }
        public string? shipTo { get; set; }
        public int invoiceId { get; set; }
        public DateTime invoiceDate { get; set; }
        public decimal invoiceAmount { get; set; }
        public int itemID { get; set; }
        //public string PartyName { get; set; } // Add this property if not already present
        //public decimal SalesPrice { get; set; } // Add this property if not already present
        //public string GSTINNumber { get; set; } // Add this property if not already present
        //public long Status { get; set; }

    }
}
