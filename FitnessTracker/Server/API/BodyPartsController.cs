using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Server.Persistence.Services.BodyPartService.cs;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;

namespace FitnessTracker.Server.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartsController : ControllerBase
    {
        private readonly IBodyPartService _bodyPartService;

        public BodyPartsController(IBodyPartService bodyPartService)
        {
            _bodyPartService = bodyPartService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BodyPart>>>> GetBodyParts()
        {
            var result = await _bodyPartService.GetBodyParts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<BodyPart>>> GetBodyPart(int id)
        {
            var result = await _bodyPartService.GetBodyPart(id);
            return Ok(result);
        }

        [HttpGet("bodyPart/{bodyPartUrl}")]
        public async Task<ActionResult<ServiceResponse<List<BodyPart>>>> GetExercisesByBodyPart(string bodyPartUrl)
        {
            var result = await _bodyPartService.GetExercises(bodyPartUrl);
            return Ok(result);
        }
    }
}
