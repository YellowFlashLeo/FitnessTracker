using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessTracker.Server.Persistence.Services.MonthlyStatistics
{
    public interface IMonthlyStatisticsService
    {
        Task<Dictionary<string, float>> BestWorkingWeightPerExercise(string userId);
        Task<float> GetAverageAmountOfRepsPerTraining(string userId);
        Task<float> GetAverageAmountOfSetsPerTraining(string userId);
        Task<double> GetAverageAmountOfCaloriesPerDay(string userId);
        Task<double> GetAverageAmountOfProteinsPerDay(string userId);
        Task<double> GetAverageAmountOfFatsPerDay(string userId);
    }
}
