using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.TrainingDayService;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain;
using FitnessTracker.Shared.Domain.Fitness;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingDayController : ControllerBase
    {
        private readonly ITrainingDayService _trainingDayService;

        public TrainingDayController(ITrainingDayService trainingDayService)
        {
            _trainingDayService = trainingDayService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TrainingDayDto>>>> GetTrainingDays()
        {
            var result = await _trainingDayService.GetAllTrainingDays(GetCurrentUserId());
            return Ok(result);
        }

        [HttpGet("{trainingDayId}")]
        public async Task<ActionResult<ServiceResponse<TrainingDayDto>>> GetTrainingDay(int trainingDayId)
        {
            var result = await _trainingDayService.GetTrainingDay(GetCurrentUserId(), trainingDayId);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> SaveDay(TrainingDay day)
        {
            var trainingDayId = await _trainingDayService.SaveTrainingDay(day, GetCurrentUserId());
            return Ok(trainingDayId.Data);
        }
        private string GetCurrentUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
