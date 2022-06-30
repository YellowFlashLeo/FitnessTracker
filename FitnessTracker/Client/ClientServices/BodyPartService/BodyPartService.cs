using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.BodyPartService
{
    public class BodyPartService : IBodyPartService
    {
        private readonly HttpClient _httpClient;

        public BodyPartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<BodyPart> BodyParts { get; set; } = new();
        public List<Exercise> Exercises { get; set; } = new();
        public BodyPart BodyPart { get; set; } = new();

        public async Task<List<BodyPart>> GetBodyParts()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<BodyPart>>>("api/BodyParts");
            BodyParts = result?.Data;
            return BodyParts;
        }

        public async Task<BodyPart> GetBodyPart(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<BodyPart>>($"api/BodyParts/{id}");
            BodyPart = result?.Data;
            return BodyPart;
        }

        public async Task<List<Exercise>> GetExercises(string bodyPartUrl)
        {
            var result =
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Exercise>>>(
                    $"api/BodyParts/bodyPart/{bodyPartUrl}");
            Exercises = result?.Data;
            return Exercises;
        }

    }
}
