using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Player;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Player
{
    public class PutPlayerByIdHandler : IRequestHandler<PutPlayerByIdRequest, PutPlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutPlayerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<PutPlayerByIdResponse> Handle(PutPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                PlayerId = request.PlayerId
            };
            var playerToEdit = await queryExecutor.Execute(query);

            var command = new PutPlayerByIdCommand()
            {
                Parameter = playerToEdit,
                NewFirstName = request.NewFirstName,
                NewLastName = request.NewLastName,
            };
            var editedPlayer =  await commandExecutor.Execute(command);
            var mappedPlayer = mapper.Map<PlayerDTO>(editedPlayer);

            var response = new PutPlayerByIdResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
