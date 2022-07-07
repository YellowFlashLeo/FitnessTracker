using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.EmailService;
using FitnessTracker.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> SendEmail(EmailDto emailBody)
        {
            emailBody.To = GetCurrentUserId();
            var orderId = await _emailService.SendEmail(emailBody);
            return Ok(orderId.Success);
        }

        private string GetCurrentUserId()
        {
            return HttpContext.User.Identity.Name;
        }
    }
}
