using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SIO
    {
        [Key]
        public int salesInvoiceId { get; set; }
        public string invoiceDate { get; set; }
        public int InvoiceID { get; set; }
        public string partyName { get; set; }
        public string shippingAddress { get; set; }

        public string dueDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
