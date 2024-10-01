using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ItemReportbyParty
    {
        [Key]
        public int id { get; set; }
        public bool ItemType { get; set; }
        public long CategoryID { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public string GSTTaxRate { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ItemCode { get; set; }
        public long HSNCode { get; set; }
        public string PartyName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public long BusinessId { get; set; }
        public decimal SalesQuantity { get; set; }
    }
}
