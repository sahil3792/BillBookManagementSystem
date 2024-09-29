using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebApi.Models
{
    public class Party
    {
        [Key]
        public int id { get; set; }
        public string PartyName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public long OpeningBalance { get; set; }
        public string GSTINNumber { get; set; }
        public string PanCardNumber { get; set; }
        public string PartyType { get; set; }
        public int PartyCategory { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public long CreditPeriod { get; set; }
        public decimal CreditLimit { get; set; }
    }
}
