using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SalesViewModel
    {
        [Key]
        public int Id { get; set; }
        public int BillTo { get; set; }
        public int ShipTo { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public int ItemID { get; set; }
        public decimal SalesQuantity { get; set; }
        public string PartyName { get; set; }
        public decimal SalesPrice { get; set; }
        public string GSTINNumber { get; set; }
        public string Status { get; set; }
    }

}
