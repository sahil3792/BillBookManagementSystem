using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        public string BusinessName { get; set; }
    }
}
