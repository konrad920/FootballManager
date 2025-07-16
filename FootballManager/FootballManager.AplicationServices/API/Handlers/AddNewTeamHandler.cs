using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
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
            var team = this.mapper.Map<Team>(request);
            var command = new AddNewTeamCommand()
            {
                Parameter = team
            };
            var teamFromDB = await this.commandExecutor.Execute(command);

            var mappedTeam = this.mapper.Map<TeamDTO>(team);
            var response = new AddNewTeamResponse()
            {
                Data = mappedTeam
            };
            return response;
        }
    }
}
