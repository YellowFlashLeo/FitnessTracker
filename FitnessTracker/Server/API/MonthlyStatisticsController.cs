using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.MonthlyStatistics;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyStatisticsController : ControllerBase
    {
        private readonly IMonthlyStatisticsService _monthlyStatisticsService;
        public MonthlyStatisticsController(IMonthlyStatisticsService monthlyStatisticsService)
        {
            _monthlyStatisticsService = monthlyStatisticsService;
        }

        [HttpGet]
        public async Task<Dictionary<string, float>> GetBestWorkingWeightPerExercise()
        {
            var result = await _monthlyStatisticsService.BestWorkingWeightPerExercise(GetCurrentUserId());
            return result;
        }

        [HttpGet]
        public async Task<float> GetAverageAmountOfRepsPerTraining()
        {
            var result = await _monthlyStatisticsService.GetAverageAmountOfRepsPerTraining(GetCurrentUserId());
            return result;
        }

        [HttpGet]
        public async Task<float> GetAverageAmountOfSetsPerTraining()
        {
            var result = await _monthlyStatisticsService.GetAverageAmountOfSetsPerTraining(GetCurrentUserId());
            return result;
        }

        [HttpGet]
        public async Task<double> GetAverageAmountOfCaloriesPerDay()
        {
            var result = await _monthlyStatisticsService.GetAverageAmountOfCaloriesPerDay(GetCurrentUserId());
            return result;
        }

        [HttpGet]
        public async Task<double> GetAverageAmountOfProteinsPerDay()
        {
            var result = await _monthlyStatisticsService.GetAverageAmountOfProteinsPerDay(GetCurrentUserId());
            return result;
        }

        [HttpGet]
        public async Task<double> GetAverageAmountOfFatsPerDay()
        {
            var result = await _monthlyStatisticsService.GetAverageAmountOfFatsPerDay(GetCurrentUserId());
            return result;
        }


        private string GetCurrentUserId()
        {
            return HttpContext.User.Identity.Name;
        }
    }
}
