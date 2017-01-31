using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class RegisterViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, enter your email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, enter your password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must contain at least {2} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password!")]
        [Compare("Password", ErrorMessage = "Passwords are different!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please, enter your surname")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Please, enter your date of birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Enter the code from the image")]
        [Required(ErrorMessage = "Please, enter the code from the image")]
        public string Captcha { get; set; }
    }
}