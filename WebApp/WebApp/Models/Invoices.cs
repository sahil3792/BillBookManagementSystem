using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Invoices
    {
        [Key]
        public int id { get; set; }
        public string Status { get; set; }
    }
}
