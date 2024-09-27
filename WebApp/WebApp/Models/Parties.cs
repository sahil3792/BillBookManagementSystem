using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MyBillBook.Models
{
    public class Parties
    {
        [Key]
        public int pId { get; set; }
        public string? partyName { get; set; }
        public string? partyEmail { get; set; }
        public string? partyPhoneNo { get; set; }
        public decimal openingBalance { get; set; }
        public string? topayTocollect { get; set; }
        public string? gstinno { get; set; }
        public string? panCardNo { get; set; }
        public string? partyType { get; set; }
        public string? partyCategory { get; set; }
        public string? partyBillingAddress { get; set; }
        public string? partyShippingAddress { get; set; }
        public string? partyCreditPeriod { get; set; }
        public string? partyCreditLimit { get; set; }
    }
}
