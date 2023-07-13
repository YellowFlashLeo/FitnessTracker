using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Identity;

namespace FitnessTracker.Server.Persistence.Services.IdentityService
{
    public interface IIdentityService
    {
        Task<ServiceResponse<bool>> doCredentialsMatch(string userName, string password);
        Task<ServiceResponse<AuthenticatingUser>> GetUserDetails(string email);
        Task<dynamic> GenerateToken(string username);
        Task<ServiceResponse<List<Gender>>> GetGenders();
    }
}
