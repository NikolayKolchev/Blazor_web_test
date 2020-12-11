using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUI.Models
{
    public class LoginModel
    {
    }

    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Enter an Email")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter a Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmedPassword { get; set; }
    }
}
