using System.Threading.Tasks;
using FitnessTracker.Shared;

namespace FitnessTracker.Server.Persistence.Services.EmailService
{
    public interface IEmailService
    {
        Task<ServiceResponse<bool>> SendEmail(EmailDto emailBody);
    }
}
