using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Statistics;
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

        public async Task<StatResults> GetOverallMonthlyStatistics(string userId)
        {
            var trainingsPerMonth = await GetLast30Days(userId);
            var stats = new StatResults();

            stats.BestWorkingWeightPerExercise = BestWorkingWeightPerExercise(trainingsPerMonth);
            stats.AverageAmountOfRepsPerTraining = GetAverageAmountOfRepsPerTraining(trainingsPerMonth);
            stats.AverageAmountOfSetsPerTraining = GetAverageAmountOfSetsPerTraining(trainingsPerMonth);
            stats.AverageAmountOfCaloriesPerDay = GetAverageAmountOfCaloriesPerDay(trainingsPerMonth);
            stats.AverageAmountOfProteinsPerDay = GetAverageAmountOfProteinsPerDay(trainingsPerMonth);
            stats.AverageAmountOfFatsPerDay = GetAverageAmountOfFatsPerDay(trainingsPerMonth);
            stats.AverageAmountOfCarbsPerDay = GetAverageAmountOfCarbsPerDay(trainingsPerMonth);

            return stats;
        }

        private async Task<List<TrainingDayDto>> GetLast30Days(string userId)
        {
            var days = await _dbContext.TrainingDaysDto.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Exercise)
                .Include(d => d.Foods)
                .OrderByDescending(d => d.Trained)
                .ToListAsync();

            return days;
        }

        private Dictionary<string, float> BestWorkingWeightPerExercise(List<TrainingDayDto> trainingsPerMonth)
        {
            var resultDict = new Dictionary<string, float>();
            foreach (var trainingDay in trainingsPerMonth)
            {
                foreach (var exerciseDto in trainingDay.Exercise)
                {
                    if (!resultDict.ContainsKey(exerciseDto.Name))
                        resultDict.Add(exerciseDto.Name, 0);

                    if (resultDict[exerciseDto.Name] < exerciseDto.Weight)
                        resultDict[exerciseDto.Name] = exerciseDto.Weight;
                }
            }

            return resultDict;
        }

        private float GetAverageAmountOfRepsPerTraining(List<TrainingDayDto> trainingsPerMonth)
        {
            var result = 0.0f;
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallReps());

            result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        private float GetAverageAmountOfSetsPerTraining(List<TrainingDayDto> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallSets());

            var result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfCaloriesPerDay(List<TrainingDayDto> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfCaloriesPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalCalories());
            var result = totalAmountOfCaloriesPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfProteinsPerDay(List<TrainingDayDto> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfProteinPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalProtein());
            var result = totalAmountOfProteinPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfFatsPerDay(List<TrainingDayDto> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfFatsPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalFats());
            var result = totalAmountOfFatsPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfCarbsPerDay(List<TrainingDayDto> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfFatsPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalCarbs());
            var result = totalAmountOfFatsPerMonth / amountOfTrainings;
            return result;
        }

    }
}
