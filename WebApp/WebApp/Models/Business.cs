using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        public string BusinessName { get; set; }
    }
}
