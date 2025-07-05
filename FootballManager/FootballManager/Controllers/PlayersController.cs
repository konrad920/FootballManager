using FootballManager.AplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlayersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("AllPlayers")]
        public async Task<IActionResult> GetAllPlayers([FromQuery] GetAllPlayersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
