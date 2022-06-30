using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Identity
{
    public class UserModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50, ErrorMessage = "First Name is too Long")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50, ErrorMessage = "Last Name is too Long")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email name is invalid")]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Range(1, 100, ErrorMessage = "Gender is not valid")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Nationality is Required")]
        [StringLength(50, ErrorMessage = "Nationality is too Long")]
        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "You do not fit into age range")]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
