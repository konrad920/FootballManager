using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Team;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Team
{
    public class DeleteTeamByIdHandler : IRequestHandler<DeleteTeamByIdRequest, DeleteTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteTeamByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteTeamByIdResponse> Handle(DeleteTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.TeamId
            };
            var teamToDelete = await this.queryExecutor.Execute(query);

            var command = new DeleteTeamByIdCommand()
            {
                Parameter = teamToDelete
            };
            var deletedTeam = await this.commandExecutor.Execute(command);
            var mappedTeam = this.mapper.Map<TeamDTO>(deletedTeam);

            var response = new DeleteTeamByIdResponse()
            {
                Data = mappedTeam
            };
            return response;
        }
    }
}
