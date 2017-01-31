using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, enter your email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        [Display(Name = "Enter your password")]
        [Required(ErrorMessage = "Please, enter your password")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
}