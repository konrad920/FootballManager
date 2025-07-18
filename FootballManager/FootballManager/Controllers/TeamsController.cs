using FootballManager.AplicationServices.API.Domain;
using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IRepository<Team> repository;

        public TeamsController(IMediator mediator, IRepository<Team> repository)
        {
            this.mediator = mediator;
            this.repository = repository;
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
