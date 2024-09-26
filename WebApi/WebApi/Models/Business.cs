using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; } 

        public string BusinessName { get; set; }  

        public string BusinessRegistrationType { get; set; }  

        public string BusinessType { get; set; }  

        public string IndustryType { get; set; }  

        public bool GSTRegistered { get; set; }  

        public long ContactNumber { get; set; }  

    }
}
