using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Shared.Domain.Nutrition
{
    public class Food
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; } = 1;
        public string ImageUrl { get; set; }
        public FoodType FoodType { get; set; }

        [ForeignKey("FoodType")] 
        public int FoodTypeId { get; set; }
        public float WeightGrams { get; set; }
        public float CaloriesPer100 { get; set; }
        public float FatsPer100 { get; set; }
        public float CarbsPer100 { get; set; }
        public float ProteinPer100 { get; set; }

        public float CalculateCalories()
        {
            var caloriesPerGram = CaloriesPer100 / 100;
            var calories = WeightGrams * caloriesPerGram * Quantity;
            return calories;
        }

        public float CalculateFats()
        {
            var fatsPerGram = FatsPer100 / 100;
            var fats = WeightGrams * fatsPerGram * Quantity;
            return fats;
        }

        public float CalculateProtein()
        {
            var proteinPerGram = ProteinPer100 / 100;
            var protein = WeightGrams * proteinPerGram * Quantity;
            return protein;
        }

        public float CalculateCarbs()
        {
            var carbsPerGram = CarbsPer100 / 100;
            var carbs = WeightGrams * carbsPerGram * Quantity;
            return carbs;
        }
    }
}
