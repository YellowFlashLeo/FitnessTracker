using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Domain.Fitness;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.TrainingDayService
{
    public class TrainingDayService : ITrainingDayService
    {
        private readonly FitnessStoreContext _dbContext;

        public TrainingDayService(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<TrainingDayDto>>> GetAllTrainingDays(string userId)
        {
            var trainingDays = await _dbContext.TrainingDaysDto.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Exercise)
                .Include(d => d.Foods)
                .OrderByDescending(o => o.Trained)
                .ToListAsync();

            return new ServiceResponse<List<TrainingDayDto>>
            {
                Data = trainingDays
            };
        }

        public async Task<ServiceResponse<TrainingDayDto>> GetTrainingDay(string userId, int trainingDayId)
        {
            var trainingDay = await _dbContext.TrainingDaysDto.Where(d => d.UserId.Equals(userId) && d.Id.Equals(trainingDayId))
                .Include(d => d.Exercise)
                .Include(d => d.Foods)
                .OrderByDescending(o => o.Trained)
                .FirstOrDefaultAsync();

            return new ServiceResponse<TrainingDayDto>
            {
                Data = trainingDay
            };
        }

        public async Task<ServiceResponse<int>> SaveTrainingDay(TrainingDay day, string userId)
        {
            day.Trained = DateTime.Now;
            day.UserId = userId;

            TrainingDayDto trialDayDto = new();
            trialDayDto.UserId = day.UserId;
            trialDayDto.Trained = day.Trained;
            trialDayDto.Foods = new List<FoodDto>();
            trialDayDto.Exercise = new List<ExerciseDto>();

            foreach (var dayMeal in day.Meals)
            {
                var foodDto = new FoodDto();
                foodDto.CaloriesPer100 = dayMeal.Food.CaloriesPer100;
                foodDto.FatsPer100 = dayMeal.Food.FatsPer100;
                foodDto.CarbsPer100 = dayMeal.Food.CarbsPer100;
                foodDto.ProteinPer100 = dayMeal.Food.ProteinPer100;
                foodDto.Quantity = dayMeal.Food.Quantity;
                foodDto.Title = dayMeal.Food.Title;
                foodDto.WeightGrams = dayMeal.Food.WeightGrams;
                foodDto.FoodTypeName = dayMeal.Food.FoodType.Name;

                trialDayDto.Foods.Add(foodDto);
            }

            foreach (var trainingExercise in day.Trainings)
            {
                var exerciseDto = new ExerciseDto();
                exerciseDto.Name = trainingExercise.Exercise.Name;
                exerciseDto.Sets = trainingExercise.Exercise.Sets;
                exerciseDto.MuscleGroup = trainingExercise.Exercise.BodyPart.Name;
                exerciseDto.RPE = trainingExercise.Exercise.RPE;
                exerciseDto.Reps = trainingExercise.Exercise.Reps;
                exerciseDto.Weight = trainingExercise.Exercise.Weight;

                trialDayDto.Exercise.Add(exerciseDto);
            }

            _dbContext.TrainingDaysDto.Add(trialDayDto);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new ServiceResponse<int>
            {
                Data = day.Id
            };
        }
    }
}
