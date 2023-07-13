using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Domain.Nutrition.Dto
{
    public class FoodDTO
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; } = 1;
        public int FoodTypeId { get; set; }
        public float WeightGrams { get; set; }
        public float CaloriesPer100 { get; set; }
        public float FatsPer100 { get; set; }
        public float CarbsPer100 { get; set; }
        public float ProteinPer100 { get; set; }

        public double CalculateCalories()
        {
            var caloriesPerGram = CaloriesPer100 / 100;
            var calories = WeightGrams * caloriesPerGram * Quantity;
            return Rounder.RoundUp(calories, 2);
        }

        public double CalculateFats()
        {
            var fatsPerGram = FatsPer100 / 100;
            var fats = WeightGrams * fatsPerGram * Quantity;
            return Rounder.RoundUp(fats, 2);
        }

        public double CalculateProtein()
        {
            var proteinPerGram = ProteinPer100 / 100;
            var protein = WeightGrams * proteinPerGram * Quantity;
            return Rounder.RoundUp(protein, 2);
        }

        public double CalculateCarbs()
        {
            var carbsPerGram = CarbsPer100 / 100;
            var carbs = WeightGrams * carbsPerGram * Quantity;
            return Rounder.RoundUp(carbs, 2);
        }
    }
}
