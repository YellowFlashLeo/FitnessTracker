using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Client.ClientServices.MonthlyStatisticsService
{
    public class MonthlyStatisticsService : IMonthlyStatisticsService
    {
        private readonly HttpClient _httpClient;

        public MonthlyStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StatResults> GetStatisticsBasedOnLast30Days()
        {
            var result = await _httpClient.GetFromJsonAsync<StatResults>("api/MonthlyStatistics");
            return result;
        }
        //public async Task<List<TrainingDayDto>> GetAllTrainingDays()
        //{
        //    var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<TrainingDayDto>>>("api/TrainingDay/");

        //    return result?.Data;
        //}

    }
}
