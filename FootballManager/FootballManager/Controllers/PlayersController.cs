using FootballManager.AplicationServices.API.Domain.Player;
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

        [HttpGet]
        [Route("ById/{playerId}")]
        public async Task<IActionResult> GetPlayerById([FromRoute] int playerId)
        {
            var request = new GetPlayerByIdRequest()
            {
                PlayerId = playerId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("AddPlayer")]
        public async Task<IActionResult> AddNewPlayer([FromBody] AddNewPlayerRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("EditById")]
        public async Task<IActionResult> EditPlayerById([FromBody] PutPlayerByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
