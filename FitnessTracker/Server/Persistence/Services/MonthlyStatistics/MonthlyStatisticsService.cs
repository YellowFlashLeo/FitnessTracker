using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
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
            stats.AverageAmountOfRepsPerTraining = trainingsPerMonth.Count.Equals(0)
                ? 0
                : Rounder.RoundUp(GetAverageAmountOfRepsPerTraining(trainingsPerMonth), 2);
            stats.AverageAmountOfSetsPerTraining = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUp(GetAverageAmountOfSetsPerTraining(trainingsPerMonth),2);
            stats.AverageAmountOfCaloriesPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfCaloriesPerDay(trainingsPerMonth),2);
            stats.AverageAmountOfProteinsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfProteinsPerDay(trainingsPerMonth),2);
            stats.AverageAmountOfFatsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfFatsPerDay(trainingsPerMonth),2);
            stats.AverageAmountOfCarbsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfCarbsPerDay(trainingsPerMonth),2);

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
