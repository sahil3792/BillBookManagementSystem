using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SalesSummaryResult
    {
        [Key]
        //public int BillTo { get; set; }
        public string InvoiceDate { get; set; }
        public int InvoiceId { get; set; }
        public string? PartyName { get; set; }
        public string DueDate { get; set; }
        public decimal Amount { get; set; }
        public string? InvoiceStatus { get; set; }
        // public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
    }
}
