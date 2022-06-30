using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Server.Persistence.Services.BodyPartService.cs
{
    public interface IBodyPartService
    {
        Task<ServiceResponse<List<BodyPart>>> GetBodyParts();
        Task<ServiceResponse<BodyPart>> GetBodyPart(int id);
        Task<ServiceResponse<List<Exercise>>> GetExercises(string bodyPartUrl);
    }
}
