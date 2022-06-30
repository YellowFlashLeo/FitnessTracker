using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Nutrition;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.NutritionService
{
    public class NutritionService : INutritionService
    {
        private readonly FitnessStoreContext _dbContext;

        public NutritionService(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<FoodType>>> GetFoodTypes()
        {
            var foodTypes = await _dbContext.FoodTypes.ToListAsync();
            return new ServiceResponse<List<FoodType>>
            {
                Data = foodTypes
            };
        }

        public async Task<ServiceResponse<FoodType>> GetFoodType(int id)
        {
            var foodType = await _dbContext.FoodTypes.FirstOrDefaultAsync(f => f.Id.Equals(id));
            return new ServiceResponse<FoodType>
            {
                Data = foodType
            };
        }

        public async Task<ServiceResponse<List<Food>>> GetFoodsByType(string foodTypeUrl)
        {
            var foodType = await _dbContext.FoodTypes.FirstOrDefaultAsync(f => f.Name.Equals(foodTypeUrl));
            var foods = await _dbContext.Foods.Where(f => f.FoodTypeId.Equals(foodType.Id)).ToListAsync();
            return new ServiceResponse<List<Food>>
            {
                Data = foods
            };
        }
    }
}
