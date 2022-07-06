using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;

namespace FitnessTracker.Shared.Domain
{
    public class TrainingDayDto
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Trained { get; set; }
        public List<ExerciseDto> Exercise { get; set; } = new();
        public List<FoodDto> Foods { get; set; } = new();

        public double GetMealsTotalCalories() => Foods.Sum(m => m.CalculateCalories());
        public double GetMealsTotalProtein() => Foods.Sum(m => m.CalculateProtein());
        public double GetMealsTotalCarbs() => Foods.Sum(m => m.CalculateCarbs());
        public double GetMealsTotalFats() => Foods.Sum(m => m.CalculateFats());

        public float GetTrainingsOverallReps() => Exercise.Sum(t => t.Reps * t.Sets);
    }
}
