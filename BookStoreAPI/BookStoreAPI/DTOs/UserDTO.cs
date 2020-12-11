using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Controllers
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
