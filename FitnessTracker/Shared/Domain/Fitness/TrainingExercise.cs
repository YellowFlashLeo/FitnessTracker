using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Domain.Fitness
{
    // Many-to-Many bridge 
    public class TrainingExercise
    {
        [Key]
        public int Id { get; set; }
        public int TrainingDayId { get; set; }
        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
    }
}
