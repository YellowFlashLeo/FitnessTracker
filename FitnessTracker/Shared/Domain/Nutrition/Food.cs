using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.Shared.Domain.Nutrition
{
    public class Food
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public FoodType FoodType { get; set; }

        [ForeignKey("FoodType")] 
        public int FoodTypeId { get; set; }
        public float CaloriesPer100 { get; set; }
        public float FatsPer100 { get; set; }
        public float CarbsPer100 { get; set; }
        public float ProteinPer100 { get; set; }
    }
}
