namespace WebApp.Models
{
    public class PurchaseRequest
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public List<MyStock> Stocks { get; set; }
    }
}
