using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
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
        private readonly FitnessStoreContext _dbContext;
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config, FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
            _config = config;
        }
        public async Task SendEmailAboutRecentTraining(TrainingDTO training)
        {
            var email = new MimeMessage();
      
            var credentials = MakeEmailBasedOnProvider(training.UserId);

            email.From.Add(MailboxAddress.Parse(credentials[1]));
            email.To.Add(MailboxAddress.Parse(training.UserId));
            email.Subject = "Progress so far!";

            email.Body = RecentTrainingDescriptor(training);

            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(credentials[0], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(credentials[1], credentials[2]);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }

        public async Task SendEmailAboutNutrition(NutritionDTO food)
        {
            var email = new MimeMessage();

            var credentials = MakeEmailBasedOnProvider(food.UserId);

            email.From.Add(MailboxAddress.Parse(credentials[1]));
            email.To.Add(MailboxAddress.Parse(food.UserId));
            email.Subject = "Progress so far!";

            email.Body = RecentMealDescriptor(food);

            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            await smtp.ConnectAsync(credentials[0], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(credentials[1], credentials[2]);
            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
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
        private MimeEntity RecentTrainingDescriptor(TrainingDTO training)
        { ;
            var bodyBuilder = new BodyBuilder();
            var exercises = training.Exercise;

            if (exercises.Any())
            {
                var uniqueBodyPartIds  = exercises.Select(x => x.BodyPartId).Distinct().ToList();
                var bodyParts = _dbContext.BodyParts.ToList();
                var muscleGroupNames = new List<string>();
                foreach (var uniqueBodyPartId in uniqueBodyPartIds)
                {
                    var bodyPartName = bodyParts.FirstOrDefault(b => b.Id.Equals(uniqueBodyPartId))?.Name;
                    muscleGroupNames.Add(bodyPartName);
                }
                bodyBuilder.HtmlBody += $"<h3>Today you trained {string.Join(',',muscleGroupNames)}</h3>";
                foreach (var exercise in exercises)
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

        private MimeEntity RecentMealDescriptor(NutritionDTO food)
        {
            var bodyBuilder = new BodyBuilder();
            var nutrients = food.Foods;
            if (nutrients.Any())
            {
                bodyBuilder.HtmlBody += "<h3>Today you consumed</h3>";

                bodyBuilder.HtmlBody += "<span>Nutrition summary</span>";
                bodyBuilder.HtmlBody += "<p>" + "<ul>" + "<li>" + "<strong>Overall Calories per Day: </strong>" + $"{nutrients.Sum(n => n.CalculateCalories())}" + "</li>" +
                                        "<li>" + "<strong>Overall Carbohydrates per Day: </strong>" + $"{nutrients.Sum(n => n.CalculateCarbs())}" +
                                        "<li>" + "<strong>Overall Protein per Day: </strong>" + $"{nutrients.Sum(n => n.CalculateProtein())}" +
                                        "<li>" + "<strong>Overall Fats per Day: </strong>" + $"{nutrients.Sum(n => n.CalculateFats())}" +
                                        "</ul>" +
                                        "</p>";
            }

            return bodyBuilder.ToMessageBody();
        }
    }
}
