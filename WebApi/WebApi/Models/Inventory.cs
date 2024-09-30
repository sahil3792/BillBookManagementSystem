using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public bool ItemType { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ItemName { get; set; }

        public decimal SalesPrice { get; set; }

        public double GSTTaxRate { get; set; }

        public string MeasuringUnit { get; set; }

        public decimal OpeningStock { get; set; }

        public decimal PurchasePrice { get; set; }

        public string ItemCode { get; set; }

        public double HSNCode { get; set; }

        public string Description { get; set; }

        public int BusinessId { get; set; }

        public string Image {  get; set; }
    }
}
