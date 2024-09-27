using System.ComponentModel.DataAnnotations;

namespace MyBillBook_Api.Models
{
    public class Parties
    {
        [Key]
        public int PId { get; set; }
        public string? PartyName { get; set; }
        public string? PartyEmail {  get; set; }
        public string? PartyPhoneNo { get; set; }
        public decimal OpeningBalance { get; set;}
        public string? TopayTocollect { get; set; }
        public string? GSTINNO { get; set; }
        public string? PanCardNo { get; set; }
        public string? PartyType { get; set; }
        public string? PartyCategory { get; set; }
        public string? PartyBillingAddress { get; set; }
        public string? PartyShippingAddress { get;set; }
        public string? PartyCreditPeriod { get;set;}
        public string? PartyCreditLimit { get; set; }
    }
}
