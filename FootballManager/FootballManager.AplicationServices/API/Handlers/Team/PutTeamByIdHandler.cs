using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Team;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Team
{
    public class PutTeamByIdHandler : IRequestHandler<PutTeamByIdRequest, PutTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutTeamByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<PutTeamByIdResponse> Handle(PutTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.TeamId
            };
            var teamToEdit = await this.queryExecutor.Execute(query);

            var command = new PutTeamByIdCommand()
            {
                Parameter = teamToEdit,
                NewName = request.NewName
            };
            var editedTeam = await this.commandExecutor.Execute(command);
            var mappedTeam = this.mapper.Map<TeamDTO>(editedTeam);

            var response = new PutTeamByIdResponse()
            {
                Data = mappedTeam
            };
            return response;
        }
    }
}
