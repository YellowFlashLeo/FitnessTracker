using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.SaveToServerService
{
    public class SaveToServerService : ISaveToServerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public SaveToServerService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<int> SaveTheDay(TrainingDay trainingDay)
        {
            await _localStorage.SetItemAsync("trainingDay", trainingDay);
            var result = await _httpClient.PostAsJsonAsync("api/TrainingDay", trainingDay);

            var newTrainingDayId = await result.Content.ReadFromJsonAsync<int>();
            return newTrainingDayId;
        }
    }
}
