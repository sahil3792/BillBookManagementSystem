using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int ItemID { get; set; }

    }
}
