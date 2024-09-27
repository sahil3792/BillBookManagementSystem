using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Invoices
    {
        [Key]
        public int InvoiceId { get; set; }
        public string Status { get; set; }
    }
}
