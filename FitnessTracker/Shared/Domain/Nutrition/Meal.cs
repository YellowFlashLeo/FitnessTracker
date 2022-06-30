using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Shared.Domain.Nutrition
{
    public class Meal
    {
        [Key] public int Id { get; set; }
        public int TrainingDayId { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
