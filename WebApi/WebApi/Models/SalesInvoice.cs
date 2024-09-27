using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class SalesInvoice
    {
        [Key]
        public int SalesInvoiceId { get; set; }
        public int PartyId { get; set; }
        public int InvoicedItemId { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public decimal Amount {  get; set; }
        public int Quantity { get; set; }






    }
}
