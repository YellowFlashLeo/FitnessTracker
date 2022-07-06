using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.TrainingDayService
{
    public class TrainingDayService :ITrainingDayService
    {
        private readonly FitnessStoreContext _dbContext;

        public TrainingDayService(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<TrainingDay>>> GetAllTrainingDays(string userId)
        {
            var trainingDays = await _dbContext.TrainingDays.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Trainings)
                .ThenInclude(d => d.Exercise)
                .Include(d=>d.Meals).ThenInclude(m=>m.Food)
                .OrderByDescending(o => o.Trained)
                .ToListAsync();

            return new ServiceResponse<List<TrainingDay>>
            {
                Data = trainingDays
            };
        }

        public async Task<ServiceResponse<TrainingDay>> GetTrainingDay(string userId, int trainingDayId)
        {
            var trainingDay = await _dbContext.TrainingDays
                .Where(d => d.UserId.Equals(userId) && d.Id.Equals(trainingDayId))
                .Include(d => d.Trainings)
                .ThenInclude(d => d.Exercise)
                .Include(d => d.Meals).ThenInclude(m => m.Food)
                .FirstOrDefaultAsync();

            return new ServiceResponse<TrainingDay>
            {
                Data = trainingDay
            };
        }

        public async Task<ServiceResponse<int>> SaveTrainingDay(TrainingDay day, string userId)
        {
            day.Trained = DateTime.Now;
            day.UserId = userId;

            //foreach (var trainingSession in day.Trainings)
            //{
            //    trainingSession.ExerciseId = trainingSession.Exercise.Id;
            //    trainingSession.Exercise = await _dbContext.Exercises.SingleOrDefaultAsync(p => p.Id.Equals(trainingSession.Exercise.Id)) ??
            //                               trainingSession.Exercise;
            //}

            //foreach (var dayMeal in day.Meals)
            //{
            //    dayMeal.FoodId = dayMeal.Food.Id;
            //    dayMeal.Food = await _dbContext.Foods.SingleOrDefaultAsync(f => f.Id.Equals(dayMeal.Food.Id)) ??
            //                   dayMeal.Food;
            //}

            _dbContext.TrainingDays.Add(day);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
            }
          

            return new ServiceResponse<int>
            {
                Data = day.Id
            };
        }
    }
}
