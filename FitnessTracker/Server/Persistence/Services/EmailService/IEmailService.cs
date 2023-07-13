using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Fitness.Dto;
using FitnessTracker.Shared.Domain.Nutrition.Dto;

namespace FitnessTracker.Server.Persistence.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAboutRecentTraining(TrainingDTO training);
        Task SendEmailAboutNutrition(NutritionDTO food);
    }
}
