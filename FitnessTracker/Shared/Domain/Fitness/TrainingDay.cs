using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public float GetMealsTotalCalories() => Meals.Sum(m => m.Food.CalculateCalories());
        public float GetMealsTotalProtein() => Meals.Sum(m => m.Food.CalculateProtein());
        public float GetMealsTotalCarbs() => Meals.Sum(m => m.Food.CalculateCarbs());
        public float GetMealsTotalFats() => Meals.Sum(m => m.Food.CalculateFats());

        public float GetTrainingsOverallSets() => Trainings.Sum(t => t.Exercise.Sets);
        public float GetTrainingsOverallReps() => Trainings.Sum(t => t.Exercise.Reps);

    }
}
