using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.NewFolder;
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

        public async Task<ServiceResponse<List<TrainingDTO>>> GetAllTrainings(string userId)
        {
            userId = "leoelo";
            var trainings = await _dbContext.TrainingDto.Where(d => d.UserId.Equals(userId))
                .Include(d=>d.Exercise)
                .OrderByDescending(d=>d.Trained)
                .ToListAsync();

            if (trainings.Count == 0)
            {
                return new ServiceResponse<List<TrainingDTO>>()
                {
                    Data = null,
                    Message = "No records found",
                    Success = false

                };
            }

            return new ServiceResponse<List<TrainingDTO>>()
            {
                Data = trainings,
                Message = "Records delivered",
                Success = true

            };
        }


        public async Task<ServiceResponse<List<NutritionDTO>>> GetAllMeals(string userId)
        {
            userId = "leoelo";
            var meals = await _dbContext.NutritionDto.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Foods)
                .OrderByDescending(d => d.MealTime)
                .ToListAsync();

            if (meals.Count == 0)
            {
                return new ServiceResponse<List<NutritionDTO>>()
                {
                    Data = null,
                    Message = "No records found",
                    Success = false
                };
            }

            return new ServiceResponse<List<NutritionDTO>>()
            {
                Data = meals,
                Message = "Records delivered",
                Success = true
            };
        }



        public async Task SaveTraining(TrainingDTO trainingDay, string userId)
        {
            trainingDay.Trained = DateTime.Now;
            trainingDay.UserId = "leoelo";
           // trainingDay.UserId = userId;

            
            _dbContext.TrainingDto.Add(trainingDay);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SaveMeal(NutritionDTO meal, string userId)
        {
            meal.MealTime = DateTime.Now;
            meal.UserId = "leoelo";

            _dbContext.NutritionDto.Add(meal);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
