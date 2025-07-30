using AutoMapper;
using FootballManager.AplicationServices.API.Domain.Coach;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Coach
{
    public class PutCoachByIdHandler : IRequestHandler<PutCoachByIdRequest, PutCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutCoachByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<PutCoachByIdResponse> Handle(PutCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachByIdQuery()
            {
                CoachId = request.CoachId
            };
            var coachToEdit = await queryExecutor.Execute(query);

            var command = new PutCoachByIdCommand()
            {
                Parameter = coachToEdit,
                NewFirstName = request.NewFirstName,
                NewSalary = request.NewSalary
            };
            var editedCoach = await commandExecutor.Execute(command);
            var mappedCoach = mapper.Map<CoachDTO>(editedCoach);

            var response = new PutCoachByIdResponse()
            {
                Data = mappedCoach
            };
            return response;
        }
    }
}
