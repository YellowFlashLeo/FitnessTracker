using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FitnessTracker.Shared.Domain.Fitness.Dto
{
    public class TrainingDTO
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Trained { get; set; }
        public List<ExerciseDTO> Exercise { get; set; } = new();

        public float GetTrainingsOverallReps() => Exercise.Sum(t => t.Reps * t.Sets);
        public float GetTrainingsOverallSets() => Exercise.Sum(t => t.Sets);
    }
}
