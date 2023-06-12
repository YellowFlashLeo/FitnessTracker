using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Shared.Domain.NewFolder
{
    public class NutritionDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime MealTime { get; set; }
        public List<FoodDTO> Foods { get; set; } = new();
        public double GetMealsTotalCalories() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateCalories()), 2);
        public double GetMealsTotalProtein() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateProtein()), 2);
        public double GetMealsTotalCarbs() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateCarbs()), 2);
        public double GetMealsTotalFats() => Rounder.RoundUpForDouble(Foods.Sum(m => m.CalculateFats()), 2);
    }
}
