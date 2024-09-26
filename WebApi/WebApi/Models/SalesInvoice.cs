using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SalesInvoice
    {
        [Key]
        public int SalesInvoiceId { get; set; }
        public int PartyId { get; set; }
        public int InvoicedItemId { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public DateOnly DueDate { get; set; }
        public int Quantity { get; set; }





    }
}
