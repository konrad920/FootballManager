using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Player;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Player
{
    public class AddNewPlayerHandler : IRequestHandler<AddNewPlayerRequest, AddNewPlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddNewPlayerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddNewPlayerResponse> Handle(AddNewPlayerRequest request, CancellationToken cancellationToken)
        {
            var player = mapper.Map< DataAccess.Entities.Player> (request);
            var command = new AddNewPlayerCommand()
            {
                Parameter = player
            };
            var playerFromDB = await commandExecutor.Execute(command);

            var mappedPlayer = mapper.Map<PlayerDTO>(playerFromDB);
            var response = new AddNewPlayerResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
