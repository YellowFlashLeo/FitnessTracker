using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.MonthlyStatisticsService
{
    public class MonthlyStatisticsService : IMonthlyStatisticsService
    {
        private readonly HttpClient _httpClient;

        public MonthlyStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TrainingDay>> GetAllTrainingDays()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<TrainingDay>>>("api/TrainingDay");

            return result?.Data;
        }
    }
}
