using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Server.Persistence.Services.TrainingDayService
{
    public interface ITrainingDayService
    {
        Task<ServiceResponse<bool>>SaveTraining(TrainingDTO trainingDay);
        Task<ServiceResponse<bool>> SaveMeal(NutritionDTO meal);
        Task<ServiceResponse<List<SortedByDay>>> GetDayTrainingsStats(string userId);
        Task<ServiceResponse<List<SortedByDayNutrients>>> GetDayNutrientsStats(string userId);
    }
}
