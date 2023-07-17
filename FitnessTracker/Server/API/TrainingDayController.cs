
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.TrainingDayService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using FitnessTracker.Shared.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : ControllerBase
    {
        private readonly ITrainingDayService _trainingDayService;

        public TrainingDayController(ITrainingDayService trainingDayService)
        {
            _trainingDayService = trainingDayService;
        }


        [HttpGet("allTrainings/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<SortedByDay>>>> GetTrainings(string userId)
        {
            var result = await _trainingDayService.GetDayTrainingsStats(userId);
            return Ok(result);
        }

        [HttpGet("allMeals/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<NutritionDTO>>>> GetMeals(string userId)
        {
            var result = await _trainingDayService.GetDayNutrientsStats(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("saveTraining")]
        public async Task SaveTraining(TrainingDTO training)
        {
            await _trainingDayService.SaveTraining(training);
        }

        [HttpPost]
        [Route("saveMeal")]
        public async Task SaveMeal(NutritionDTO meal)
        {
           await _trainingDayService.SaveMeal(meal);
        }


        private string GetCurrentUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
