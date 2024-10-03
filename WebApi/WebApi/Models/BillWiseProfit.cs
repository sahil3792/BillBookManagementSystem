using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BillWiseProfit
    {
        [Key]
        public int BillTo { get; set; }
        //public int inoiceid {get; set; }
        public int InventoryItemid { get; set; }
        public string? PartyName { get; set; }
        public string invoicedate { get; set; }
        public decimal Amount { get; set; }
        public decimal salesprice { get; set; }
        public decimal purchaseprice { get; set; }
        public decimal Profit { get; set; }
    }
}
