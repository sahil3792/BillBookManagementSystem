﻿namespace Invoice.Models
{
    public class Parties
    {
        public class Party
        {
            public int Id { get; set; }  
            public string PartyName { get; set; } 
            public string Email { get; set; }  
            public long PhoneNumber { get; set; }  
            public decimal OpeningBalance { get; set; }  
            public string GSTINNumber { get; set; }  
            public string PanCardNumber { get; set; }  
            public string PartyType { get; set; }  
            public string PartyCategory { get; set; }  
            public string BillingAddress { get; set; }  
            public string ShippingAddress { get; set; }  
            public int CreditPeriod { get; set; }  
            public decimal CreditLimit { get; set; }  
        }

    }
}
