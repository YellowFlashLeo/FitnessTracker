using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.Services.MonthlyStatistics;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Statistics;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyStatisticsController : ControllerBase
    {
        private readonly IMonthlyStatisticsService _monthlyStatisticsService;
        public MonthlyStatisticsController(IMonthlyStatisticsService monthlyStatisticsService)
        {
            _monthlyStatisticsService = monthlyStatisticsService;
        }

        [HttpGet("stats")]
        public async Task<ActionResult<ServiceResponse<StatResults>>> GetMonthlyStats()
        {
            var result = await _monthlyStatisticsService.GetMonthlyStats(GetCurrentUserId());
            return result;
        }

        private string GetCurrentUserId()
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
