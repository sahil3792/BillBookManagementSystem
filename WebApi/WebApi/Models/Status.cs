using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Status
    {
        [Key]
        public int Invoiceid { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceStatus { get; set; }
    }
}
