using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.NewFolder;
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

        public async Task<ServiceResponse<StatResults>> GetMonthlyStats(string userId)
        {
            userId = "leoelo";
            var trainingsPerMonth = await GetLast30DaysWorkouts(userId);
            var mealsPerMonth = await GetLast30DaysMeals(userId);

            if (trainingsPerMonth.Count.Equals(0) && mealsPerMonth.Count.Equals(0))
            {
                return new ServiceResponse<StatResults>()
                {
                    Success = false,
                    Message = "No records found",
                    Data = new StatResults()
                };
            }


            var stats = new StatResults();

            stats.BestWorkingWeightPerExercise = BestWorkingWeightPerExercise(trainingsPerMonth);
            stats.AverageAmountOfRepsPerTraining = trainingsPerMonth.Count.Equals(0)
                ? 0
                : Rounder.RoundUp(GetAverageAmountOfRepsPerTraining(trainingsPerMonth), 2);
            stats.AverageAmountOfSetsPerTraining = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUp(GetAverageAmountOfSetsPerTraining(trainingsPerMonth), 2);
            stats.AverageAmountOfCaloriesPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfCaloriesPerDay(mealsPerMonth), 2);
            stats.AverageAmountOfProteinsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfProteinsPerDay(mealsPerMonth), 2);
            stats.AverageAmountOfFatsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfFatsPerDay(mealsPerMonth), 2);
            stats.AverageAmountOfCarbsPerDay = trainingsPerMonth.Count.Equals(0) ? 0 : Rounder.RoundUpForDouble(GetAverageAmountOfCarbsPerDay(mealsPerMonth), 2);

            return new ServiceResponse<StatResults>()
            {
                Success = true,
                Message = "Records delivered",
                Data = stats
            };
        }

        private async Task<List<TrainingDTO>> GetLast30DaysWorkouts(string userId)
        {
            var trainings = await _dbContext.TrainingDto.Where(d => d.UserId.Equals(userId))
                                                                       .Include(d => d.Exercise)
                                                                       .OrderByDescending(d => d.Trained)
                                                                       .ToListAsync();
            return trainings;
        }

        private async Task<List<NutritionDTO>> GetLast30DaysMeals(string userId)
        {
            var meals = await _dbContext.NutritionDto.Where(d => d.UserId.Equals(userId))
                                                                     .Include(d => d.Foods)
                                                                     .OrderByDescending(d => d.MealTime)
                                                                     .ToListAsync();

            return meals;
        }

        private Dictionary<string, float> BestWorkingWeightPerExercise(List<TrainingDTO> trainingsPerMonth)
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

        private float GetAverageAmountOfRepsPerTraining(List<TrainingDTO> trainingsPerMonth)
        {
            var result = 0.0f;
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallReps());

            result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        private float GetAverageAmountOfSetsPerTraining(List<TrainingDTO> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfRepsPerMonth = trainingsPerMonth.Sum(training => training.GetTrainingsOverallSets());

            var result = totalAmountOfRepsPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfCaloriesPerDay(List<NutritionDTO> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfCaloriesPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalCalories());
            var result = totalAmountOfCaloriesPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfProteinsPerDay(List<NutritionDTO> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfProteinPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalProtein());
            var result = totalAmountOfProteinPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfFatsPerDay(List<NutritionDTO> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfFatsPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalFats());
            var result = totalAmountOfFatsPerMonth / amountOfTrainings;
            return result;
        }

        private double GetAverageAmountOfCarbsPerDay(List<NutritionDTO> trainingsPerMonth)
        {
            var amountOfTrainings = trainingsPerMonth.Count;
            var totalAmountOfFatsPerMonth = trainingsPerMonth.Sum(training => training.GetMealsTotalCarbs());
            var result = totalAmountOfFatsPerMonth / amountOfTrainings;
            return result;
        }
    }
}
