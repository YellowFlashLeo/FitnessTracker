using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Server.Persistence.Services.IdentityService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly FitnessStoreContext _dbContext;
        private readonly UserManager<FitnessAppUser> _userManager;
        private readonly IIdentityService _identityService;

        public IdentityController(FitnessStoreContext dbContext, UserManager<FitnessAppUser> userManager, IIdentityService identityService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _identityService = identityService;
        }

        public record UserRegistrationModel(string FirstName, string LastName, string EmailAddress, string Password, string Nationality, int Age, int GenderId);

        [HttpPost]
        [Route("/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationModel userToBeRegistered)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(userToBeRegistered.EmailAddress);
                if (existingUser is null)
                {
                    FitnessAppUser newUser = new()
                    {
                        FirstName = userToBeRegistered.FirstName,
                        LastName = userToBeRegistered.LastName,
                        GenderId = userToBeRegistered.GenderId,
                        Nationality = userToBeRegistered.Nationality,
                        Age = userToBeRegistered.Age,
                        Email = userToBeRegistered.EmailAddress,
                        EmailConfirmed = true,
                        Password = userToBeRegistered.Password,
                        UserName = userToBeRegistered.EmailAddress
                    };

                    IdentityResult result = await _userManager.CreateAsync(newUser, userToBeRegistered.Password);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Gender>>>> GetGenders()
        {
            var result = await _identityService.GetGenders();
            return Ok(result);
        }

        [Route("/token")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AuthenticatingUser model)
        {
            if (await _identityService.doCredentialsMatch(model.Email, model.Password))
            {
                return Ok(await _identityService.GenerateToken(model.Email));
            }

            return BadRequest();
        }
    }
}
