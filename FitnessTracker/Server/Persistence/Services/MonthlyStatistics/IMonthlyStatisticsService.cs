using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Server.Persistence.Services.MonthlyStatistics
{
    public interface IMonthlyStatisticsService
    {
        Task<ServiceResponse<StatResults>> GetOverallMonthlyStatistics(string userId);
    }
}
