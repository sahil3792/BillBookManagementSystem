using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Businesses
    {
        [Key]
        public int BusinessId { get; set; }

        public string? BusinessName { get; set; }

        public string? BusinessRegistrationType { get; set; }

        public string? BusinessType { get; set; }

        public string? IndustryType { get; set; }

        public Boolean? GSTRegistered { get; set; }

        public double? ContactNumber { get; set; }

    }
}
