using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Client.Authentication
{
    public class AuthenticatingUser
    {
        [Required(ErrorMessage = "Email Address is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
