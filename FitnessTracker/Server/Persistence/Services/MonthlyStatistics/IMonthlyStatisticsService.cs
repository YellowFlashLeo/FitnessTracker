using System.Threading.Tasks;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Server.Persistence.Services.MonthlyStatistics
{
    public interface IMonthlyStatisticsService
    {
        Task<StatResults> GetOverallMonthlyStatistics(string userId);
    }
}
