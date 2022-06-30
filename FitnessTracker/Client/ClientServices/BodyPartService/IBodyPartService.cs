using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Client.ClientServices.BodyPartService
{
    public interface IBodyPartService
    {
        Task<List<BodyPart>> GetBodyParts();
        Task<BodyPart> GetBodyPart(int id);
        Task<List<Exercise>> GetExercises(string bodyPartUrl);
    }
}
