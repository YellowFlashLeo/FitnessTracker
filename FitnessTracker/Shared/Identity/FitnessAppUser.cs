using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Shared.Identity
{
   public class FitnessAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        [ForeignKey("Id")]
        public int GenderId { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
