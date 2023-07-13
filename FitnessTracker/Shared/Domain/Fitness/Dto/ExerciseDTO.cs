using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Domain.Fitness.Dto
{
    public class ExerciseDTO
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int BodyPartId { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public int Sets { get; set; }
        public int RPE { get; set; }
    }
}
