using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.NutritionService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Nutrition;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly INutritionService _nutritionService;

        public NutritionController(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FoodType>>>> GetFoodTypes()
        {
            var result = await _nutritionService.GetFoodTypes();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FoodType>>> GetFoodType(int id)
        {
            var result = await _nutritionService.GetFoodType(id);

            return Ok(result);
        }

        [HttpGet("foodType/{foodTypeUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Food>>>> GetFoodsByFoodType(string foodTypeUrl)
        {
            var result = await _nutritionService.GetFoodsByType(foodTypeUrl);
            return Ok(result);
        }
    }
}
