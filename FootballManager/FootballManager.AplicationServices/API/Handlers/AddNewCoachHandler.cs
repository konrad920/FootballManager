using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class AddNewCoachHandler : IRequestHandler<AddNewCoachRequest, AddNewCoachResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddNewCoachHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddNewCoachResponse> Handle(AddNewCoachRequest request, CancellationToken cancellationToken)
        {
            var coach = this.mapper.Map<Coach>(request);
            var command = new AddNewCoachCommand()
            {
                Parameter = coach
            };
            var coachFromDB = await this.commandExecutor.Execute(command);

            var mappedCoach = this.mapper.Map<CoachDTO>(coachFromDB);
            var response = new AddNewCoachResponse()
            {
                Data = mappedCoach
            };
            return response;
        }
    }
}
