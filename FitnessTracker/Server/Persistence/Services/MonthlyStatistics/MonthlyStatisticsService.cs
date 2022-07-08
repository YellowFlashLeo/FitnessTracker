using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.MonthlyStatistics
{
    public class MonthlyStatisticsService : IMonthlyStatisticsService
    {
        private readonly FitnessStoreContext _dbContext;

        public MonthlyStatisticsService(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        private async Task<List<TrainingDayDto>> GetLast30Days(string userId)
        {
            var days =  await _dbContext.TrainingDaysDto.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Exercise)
                .Include(d => d.Foods)
                .OrderByDescending(d => d.Trained)
                .ToListAsync();

            return new List<TrainingDayDto>();
        }

        public async Task<Dictionary<string, float>> BestWorkingWeightPerExercise(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var resultDict = new Dictionary<string, float>();
            foreach (var exerciseDto in trainingsPerMonth.SelectMany(trainingDayDto => trainingDayDto.Exercise.Where(exerciseDto => resultDict[exerciseDto.Name] < exerciseDto.Weight)))
            {
                resultDict.Add(exerciseDto.Name, exerciseDto.Weight);
            }

            return resultDict;
        }

        public async Task<float> GetAverageAmountOfRepsPerTraining(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var result = 0.0f;
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallReps());

            result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        public async Task<float> GetAverageAmountOfSetsPerTraining(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallSets());

            var result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        public async Task<double> GetAverageAmountOfCaloriesPerDay(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfCaloriesPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalCalories());
            var result = totalAmountOfCaloriesPerMonth / amountOfTrainings;
            return result;
        }

        public async Task<double> GetAverageAmountOfProteinsPerDay(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfProteinPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalProtein());
            var result = totalAmountOfProteinPerMonth / amountOfTrainings;
            return result;
        }

        public async Task<double> GetAverageAmountOfFatsPerDay(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);

            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfFatsPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalFats());
            var result = totalAmountOfFatsPerMonth / amountOfTrainings;
            return result;
        }

    }
}
