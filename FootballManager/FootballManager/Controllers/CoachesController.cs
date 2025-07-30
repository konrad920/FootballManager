using FootballManager.AplicationServices.API.Domain.Coach;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoachesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CoachesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("AllCoaches")]
        public async Task<IActionResult> GetAllCoaches([FromQuery] GetAllCoachesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("ById/{coachId}")]
        public async Task<IActionResult> GetCoachById([FromRoute] int coachId)
        {
            var request = new GetCoachByIdRequest()
            {
                CoachId = coachId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("AddCoach")]
        public async Task<IActionResult> AddNewCoach([FromBody] AddNewCoachRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("EditById")]
        public async Task<IActionResult> EditCoachById([FromBody] PutCoachByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
