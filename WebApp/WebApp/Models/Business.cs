using Microsoft.AspNetCore.Http.HttpResults;

namespace Invoice.Models
{
    public class Business
    {
        public int Id { get; set; } 

        public string BusinessName { get; set; }  

        public string BusinessRegistrationType { get; set; }  

        public string BusinessType { get; set; }  

        public string IndustryType { get; set; }  

        public bool GSTRegistered { get; set; }  

        public long ContactNumber { get; set; } 
    }
}
