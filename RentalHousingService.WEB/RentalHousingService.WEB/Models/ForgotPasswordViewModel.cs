using System.ComponentModel.DataAnnotations;

namespace RentalHousingService.WEB.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Post")]
        public string Email { get; set; }
    }
}