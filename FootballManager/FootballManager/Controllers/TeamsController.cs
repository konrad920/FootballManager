using FootballManager.AplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("AllTeams")]
        public async Task<IActionResult> GetAllTeams([FromQuery] GetAllTeamsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("AddTeam")]
        public async Task<IActionResult> AddNewTeam([FromBody] AddNewTeamRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
