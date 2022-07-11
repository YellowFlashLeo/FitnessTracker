using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Client.ClientServices.MonthlyStatisticsService
{
    public interface IMonthlyStatisticsService
    {
        Task<List<TrainingDayDto>> GetAllTrainingDays();
        Task<StatResults> GetStatisticsBasedOnLast30Days();
    }
}
