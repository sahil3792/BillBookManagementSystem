using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Business Name is required.")]
        [Display(Name = "Your Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Business Registration Type is required.")]
        [Display(Name = "Business Registration Type")]

        public string BusinessRegistrationType { get; set; }

        [Required(ErrorMessage = "Business Type is required.")]
        [Display(Name = "Business Type")]

        public string BusinessType { get; set; }

        [Required(ErrorMessage = "Industry Type is required.")]
        [Display(Name = "Industry Type")]


        public string IndustryType { get; set; }

        [Display(Name = "GST Number")]
        
        public string GSTNumber { get; set; }
        [Required(ErrorMessage = "Please specify if your business is GST registered.")]
        [Display(Name = "GST Registered")]
        public Boolean GSTRegistered {  get; set; }
        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber {  get; set; }
        public string Email { get; set; }

    }
}
