using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
