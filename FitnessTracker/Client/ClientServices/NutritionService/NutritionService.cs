using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Nutrition;

namespace FitnessTracker.Client.ClientServices.NutritionService
{
    public class NutritionService : INutritionService
    {
        private readonly HttpClient _httpClient;

        public NutritionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<FoodType> FoodTypes { get; set; } = new();
        public List<Food> Foods { get; set; } = new();
        public FoodType FoodType { get; set; } = new();

        public async Task<List<FoodType>> GetFoodTypes()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<FoodType>>>("api/Nutrition");
            FoodTypes = result?.Data;
            return FoodTypes;
        }

        public async Task<FoodType> GetFoodType(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<FoodType>>($"api/Nutrition/{id}");
            FoodType = result?.Data;
            return FoodType;
        }

        public async Task<List<Food>> GetFoods(string foodTypeUrl)
        {
            var result =
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Food>>>(
                    $"api/Nutrition/foodType/{foodTypeUrl}");

            Foods = result?.Data;
            return Foods;
        }
    }
}
