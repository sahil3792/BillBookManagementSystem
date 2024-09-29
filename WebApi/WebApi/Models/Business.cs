using System.ComponentModel.DataAnnotations;

namespace Items.Models
{
    public class Business
    {
        [Key]
        public int BusinessId { get; set; }

        public string BusinessName { get; set; }
    }
}
