using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Invoices
    {
        [Key]
        public int id { get; set; }
        public string Status { get; set; }
    }
}
