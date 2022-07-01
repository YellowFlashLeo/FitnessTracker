using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.MonthlyStatisticsService
{
    public interface IMonthlyStatisticsService
    {
        Task<List<TrainingDay>> GetAllTrainingDays();
    }
}
