using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Shared.Domain.Fitness
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public BodyPart BodyPart { get; set; }
        [ForeignKey("BodyPart")]
        public int BodyPartId { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public int Sets { get; set; }
        public int RPE { get; set; }
        public string ImageUrl { get; set; }
    }
}
