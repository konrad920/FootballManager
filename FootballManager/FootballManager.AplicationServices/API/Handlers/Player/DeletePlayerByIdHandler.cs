using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Player;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Player
{
    public class DeletePlayerByIdHandler : IRequestHandler<DeletePlayerByIdRequest, DeletePlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeletePlayerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeletePlayerByIdResponse> Handle(DeletePlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                PlayerId = request.PlayerId
            };
            var playerToDelete = await this.queryExecutor.Execute(query);

            var command = new DeletePlayerByIdCommand()
            {
                Parameter = playerToDelete
            };
            var deletedPlayer = await this.commandExecutor.Execute(command);
            var mappedPlayer = this.mapper.Map<PlayerDTO>(deletedPlayer);

            var response = new DeletePlayerByIdResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
