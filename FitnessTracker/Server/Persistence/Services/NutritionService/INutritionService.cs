using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Nutrition;

namespace FitnessTracker.Server.Persistence.Services.NutritionService
{
    public interface INutritionService
    {
        Task<ServiceResponse<List<FoodType>>> GetFoodTypes();
        Task<ServiceResponse<FoodType>> GetFoodType(int id);
        Task<ServiceResponse<List<Food>>> GetFoodsByType(string foodTypeUrl);
    }
}
