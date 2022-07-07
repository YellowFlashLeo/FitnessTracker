using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Domain.Fitness;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace FitnessTracker.Server.Persistence.Services.EmailService
{
    public class EmailService :IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<ServiceResponse<bool>> SendEmail(EmailDto emailBody)
        {
            var email = new MimeMessage();
      
            var credentials = MakeEmailBasedOnProvider(emailBody.To);

            email.From.Add(MailboxAddress.Parse(credentials[1]));
            email.To.Add(MailboxAddress.Parse(emailBody.To));
            email.Subject = emailBody.Subject;

            email.Body =  EmailBodyGenerator(emailBody.Body);

            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(credentials[0], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(credentials[1], credentials[2]);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
            return new ServiceResponse<bool>
            {
               Success = true
            };
        }

        private List<string> MakeEmailBasedOnProvider(string emailBody)
        {
            var credentials = new List<string>();
            var emailIdentifier = string.Empty;

            if (emailBody.Contains("outlook"))
                emailIdentifier += "outlook";

            if (emailBody.Contains("gmail"))
                emailIdentifier += "gmail";
            switch (emailIdentifier)
            {
                case "gmail":
                    credentials.Add(_config.GetSection("EmailHostGmail").Value);
                    credentials.Add(_config.GetSection("EmailUserNameGmail").Value);
                    credentials.Add(_config.GetSection("EmailPasswordGmail").Value);
                    break;
                case "outlook":
                    credentials.Add(_config.GetSection("EmailHostOutlook").Value);
                    credentials.Add(_config.GetSection("EmailUserNameOutlook").Value);
                    credentials.Add(_config.GetSection("EmailPasswordOutlook").Value);
                    break;
            }

            return credentials;
        }
        private MimeEntity EmailBodyGenerator(TrainingDay trainingDay)
        {
            var trainingDayDto = ConvertTrainingDayToDto(trainingDay);
            var bodyBuilder = new BodyBuilder();

            if (trainingDayDto.Foods.Any())
            {
                bodyBuilder.HtmlBody += "<h3>Today you consumed</h3>";
                foreach (var food in trainingDayDto.Foods)
                {
                    bodyBuilder.HtmlBody += "<p>" + $"<strong>{food.Title} Grams: {food.WeightGrams}g </strong>" +
                                            "</p>" +
                                            "<span>Food Nutrients</span>" +
                                            "<ul>" + $"<li>Calories: {food.CalculateCalories()}</li>" +
                                            $"<li>Carbohydrates: {food.CalculateCarbs()}</li>" +
                                            $"<li>Protein: {food.CalculateProtein()}</li>" +
                                            $"<li>Fats: {food.CalculateFats()}</li>" +
                                            "</ul>";
                }

                bodyBuilder.HtmlBody += "<span>Nutrition summary</span>";
                bodyBuilder.HtmlBody += "<p>" + "<ul>" + "<li>" + "<strong>Overall Calories per Day: </strong>" + $"{trainingDayDto.GetMealsTotalCalories()}" + "</li>" +
                                        "<li>" + "<strong>Overall Carbohydrates per Day: </strong>" + $"{trainingDayDto.GetMealsTotalCarbs()}" +
                                        "<li>" + "<strong>Overall Protein per Day: </strong>" + $"{trainingDayDto.GetMealsTotalProtein()}" +
                                        "<li>" + "<strong>Overall Fats per Day: </strong>" + $"{trainingDayDto.GetMealsTotalFats()}" +
                                        "</ul>" +
                                        "</p>";
            }

            if (trainingDayDto.Exercise.Any())
            {
                bodyBuilder.HtmlBody += $"<h3>Today you trained {trainingDayDto.Exercise.FirstOrDefault()?.MuscleGroup}</h3>";
                foreach (var exercise in trainingDayDto.Exercise)
                {
                    bodyBuilder.HtmlBody += $"<p><strong>{exercise.Name}</strong></p>" +
                                            "<ul>" +
                                            $"<li>Weight: {exercise.Weight} kg </li>" +
                                            $"<li>Sets: {exercise.Sets} </li>" +
                                            $"<li>Reps per Set: {exercise.Reps} </li>" +
                                            $"<li>RPE: {exercise.RPE} </li>" +
                                            "</ul>";
                }
            }

            return bodyBuilder.ToMessageBody();

        }

        private TrainingDayDto ConvertTrainingDayToDto(TrainingDay trainingDay)
        {
            TrainingDayDto trialDayDto = new();
            trialDayDto.UserId = trainingDay.UserId;
            trialDayDto.Trained = trainingDay.Trained;
            trialDayDto.Foods = new List<FoodDto>();
            trialDayDto.Exercise = new List<ExerciseDto>();

            foreach (var dayMeal in trainingDay.Meals)
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

            foreach (var trainingExercise in trainingDay.Trainings)
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

            return trialDayDto;
        }
    }
}
