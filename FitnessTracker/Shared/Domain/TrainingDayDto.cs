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

        public double GetMealsTotalCalories() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateCalories()),2);
        public double GetMealsTotalProtein() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateProtein()),2);
        public double GetMealsTotalCarbs() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateCarbs()),2);
        public double GetMealsTotalFats() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateFats()),2);

        public float GetTrainingsOverallReps() => Exercise.Sum(t => t.Reps * t.Sets);

        public float GetTrainingsOverallSets() => Exercise.Sum(t => t.Sets);
    }
}
