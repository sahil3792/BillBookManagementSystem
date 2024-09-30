namespace WebApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public int StockQuantity { get; set; }
        public int UnitPrice { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
