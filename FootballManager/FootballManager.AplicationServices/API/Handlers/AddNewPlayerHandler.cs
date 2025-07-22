using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
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
            var player = this.mapper.Map<Player>(request);
            var command = new AddNewPlayerCommand()
            {
                Parameter = player
            };
            var playerFromDB = await this.commandExecutor.Execute(command);

            var mappedPlayer = this.mapper.Map<PlayerDTO>(playerFromDB);
            var response = new AddNewPlayerResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
