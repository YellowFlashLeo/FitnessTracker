using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessTracker.Shared.Domain.Nutrition;

namespace FitnessTracker.Shared.Domain.Fitness
{
   public class TrainingDay
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Trained { get; set; }
        public List<TrainingExercise> Trainings { get; set; } = new();
        public List<Meal> Meals { get; set; } = new();
    }
}
