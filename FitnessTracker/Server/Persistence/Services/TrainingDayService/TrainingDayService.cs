using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Server.Persistence.Services.BodyPartService.cs;
using FitnessTracker.Server.Persistence.Services.EmailService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using FitnessTracker.Shared.Statistics;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.TrainingDayService
{
    public class TrainingDayService : ITrainingDayService
    {
        private readonly FitnessStoreContext _dbContext;
        private readonly IBodyPartService _bodyPartService;
        private readonly IEmailService _emailService;

        public TrainingDayService(FitnessStoreContext dbContext, IBodyPartService bodyPartService, IEmailService emailService)
        {
            _dbContext = dbContext;
            _bodyPartService = bodyPartService;
            _emailService = emailService;
        }

        public async Task<ServiceResponse<List<SortedByDay>>> GetDayTrainingsStats(string userId)
        {
            userId = "leoelo";
            var trainings = await _dbContext.TrainingDto.Where(d => d.UserId.Equals(userId))
                .Include(d=>d.Exercise)
                .OrderByDescending(d=>d.Trained)
                .ToListAsync();

            if (trainings.Count == 0)
            {
                return new ServiceResponse<List<SortedByDay>>()
                {
                    Data = null,
                    Message = "No records found",
                    Success = false

                };
            }
            else
            {
                var bodyParts = _bodyPartService.GetBodyParts().Result.Data;
                var result = new List<SortedByDay>();
                var sortedByDateTrainings = new Dictionary<int, List<ExerciseDTO>>();

                
                foreach (var training in trainings)
                {
                    if (sortedByDateTrainings.ContainsKey(training.Trained.DayOfYear))
                        sortedByDateTrainings[training.Trained.DayOfYear].AddRange(training.Exercise);
                    else 
                        sortedByDateTrainings[training.Trained.DayOfYear] = training.Exercise;
                }

                foreach (var sortedByDateTraining in sortedByDateTrainings)
                {
                    var bodyPartIds = sortedByDateTraining.Value.Select(s => s.BodyPartId).Distinct().ToList();
                    var muscles = new List<string>();
                    bodyPartIds.ForEach(f => muscles.Add(bodyParts.Find(b => b.Id.Equals(f)).Name));

                    result.Add(new SortedByDay
                    {
                        DayOfTheYear = sortedByDateTraining.Key,
                        Exercises = sortedByDateTraining.Value,
                        MuscleGroups = muscles
                    });
                }

                return new ServiceResponse<List<SortedByDay>>()
                {
                    Data = result,
                    Message = "Records delivered",
                    Success = true

                };
            }
        }


        public async Task<ServiceResponse<List<SortedByDayNutrients>>> GetDayNutrientsStats(string userId)
        {
            userId = "leoelo";
            var meals = await _dbContext.NutritionDto.Where(d => d.UserId.Equals(userId))
                .Include(d => d.Foods)
                .OrderByDescending(d => d.MealTime)
                .ToListAsync();

            if (meals.Count == 0)
            {
                return new ServiceResponse<List<SortedByDayNutrients>>()
                {
                    Data = null,
                    Message = "No records found",
                    Success = false
                };
            }


            var result = new List<SortedByDayNutrients>();
            var sortedByDateMeals = new Dictionary<int, List<NutritionDTO>>();


            foreach (var meal in meals)
            {
                if (sortedByDateMeals.ContainsKey(meal.MealTime.DayOfYear))
                    sortedByDateMeals[meal.MealTime.DayOfYear].Add(meal);
                else
                    sortedByDateMeals[meal.MealTime.DayOfYear] = new List<NutritionDTO>{meal};
            }

            foreach (var sortedByDateMeal in sortedByDateMeals)
            {
                var calories = sortedByDateMeal.Value.Sum(m => m.GetMealsTotalCalories());
                var carbs = sortedByDateMeal.Value.Sum(m => m.GetMealsTotalCarbs());
                var proteins = sortedByDateMeal.Value.Sum(m => m.GetMealsTotalProtein());
                var fats = sortedByDateMeal.Value.Sum(m => m.GetMealsTotalFats());
                result.Add(new SortedByDayNutrients()
                {
                    DayOfTheYear = sortedByDateMeal.Key,
                    DayCalories = calories,
                    DayCarbs = carbs,
                    DayFats = fats,
                    DayProteins = proteins
                });
            }

            return new ServiceResponse<List<SortedByDayNutrients>>()
            {
                Data = result,
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
                await _emailService.SendEmailAboutRecentTraining(trainingDay);
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
                await _emailService.SendEmailAboutNutrition(meal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
