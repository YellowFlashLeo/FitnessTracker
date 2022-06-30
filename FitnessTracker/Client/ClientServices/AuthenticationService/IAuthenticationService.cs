using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Shared.Identity;

namespace FitnessTracker.Client.ClientServices.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<bool> RegisterUser(UserModel model);
        Task<AuthenticatedUser> Login(AuthenticatingUser userToBeAuthenticated);
        Task<List<Gender>> GetGenders();
        Task Logout();
    }
}
