using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public string ItemType { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public string GSTTaxRate { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ItemCode { get; set; }
        public long HSNCode { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int BusinessId { get; set; }
    }
}
