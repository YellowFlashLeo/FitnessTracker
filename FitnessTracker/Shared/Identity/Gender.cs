using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Identity
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
