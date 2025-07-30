using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Team;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Team
{
    public class AddNewTeamHandler : IRequestHandler<AddNewTeamRequest, AddNewTeamResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddNewTeamHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddNewTeamResponse> Handle(AddNewTeamRequest request, CancellationToken cancellationToken)
        {
            var team = mapper.Map<DataAccess.Entities.Team>(request);
            var command = new AddNewTeamCommand()
            {
                Parameter = team
            };
            var teamFromDB = await commandExecutor.Execute(command);

            var mappedTeam = mapper.Map<TeamDTO>(team);
            var response = new AddNewTeamResponse()
            {
                Data = mappedTeam
            };
            return response;
        }
    }
}
