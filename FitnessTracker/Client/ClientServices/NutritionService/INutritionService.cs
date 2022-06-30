using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Nutrition;

namespace FitnessTracker.Client.ClientServices.NutritionService
{
   public interface INutritionService
   {
       Task<List<FoodType>> GetFoodTypes();
       Task<FoodType> GetFoodType(int id);
       Task<List<Food>> GetFoods(string foodTypeUrl);
   }
}
