
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.TrainingDayService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.NewFolder;
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


        [HttpGet("allTrainings")]
        public async Task<ActionResult<ServiceResponse<List<TrainingDTO>>>> GetTrainings()
        {
            var result = await _trainingDayService.GetAllTrainings(GetCurrentUserId());
            return Ok(result);
        }

        [HttpGet("allMeals")]
        public async Task<ActionResult<ServiceResponse<List<NutritionDTO>>>> GetMeals()
        {
            var result = await _trainingDayService.GetAllMeals(GetCurrentUserId());
            return Ok(result);
        }

        [HttpPost]
        [Route("saveTraining")]
        public async Task SaveTraining(TrainingDTO training)
        {
            await _trainingDayService.SaveTraining(training, GetCurrentUserId());
        }

        [HttpPost]
        [Route("saveMeal")]
        public async Task SaveMeal(NutritionDTO meal)
        {
           await _trainingDayService.SaveMeal(meal, GetCurrentUserId());
        }


        private string GetCurrentUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
