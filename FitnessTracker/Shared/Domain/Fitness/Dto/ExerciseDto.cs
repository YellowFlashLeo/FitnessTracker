using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Domain.Fitness.Dto
{
    public class ExerciseDto
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public int Sets { get; set; }
        public int RPE { get; set; }
    }
}
