namespace WebApi.Models
{
    public class PartyOutsandingViewModel
    {
        public int Id { get; set; }
        public string InvoiceDate { get; set; }
        public string PartyName { get; set; }
        public string GSTINNumber { get; set; }
        public string PartyCategory { get; set; }
        public long PhoneNumber { get; set; }
        public decimal ClosingBalance { get; set; }
    }
}
