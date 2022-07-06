using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Server.Persistence.Services.TrainingDayService
{
    public interface ITrainingDayService
    {
        Task<ServiceResponse<List<TrainingDayDto>>> GetAllTrainingDays(string userId);
        Task<ServiceResponse<TrainingDayDto>> GetTrainingDay(string userId, int trainingDayId);
        Task<ServiceResponse<int>> SaveTrainingDay(TrainingDay day, string userId);
    }
}
