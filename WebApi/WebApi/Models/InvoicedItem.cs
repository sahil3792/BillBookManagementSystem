using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class InvoicedItem
    {
        [Key]
        public int InvoiceditemId { get; set; }

        public int SalesInvoiceId { get; set; }

        public int ItemId { get; set; }


    }
}
