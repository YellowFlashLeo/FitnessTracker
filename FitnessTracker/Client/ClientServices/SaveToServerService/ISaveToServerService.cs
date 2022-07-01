using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.SaveToServerService
{
    public interface ISaveToServerService
    {
        Task<int> SaveTheDay(TrainingDay trainingDay);
    }
}
