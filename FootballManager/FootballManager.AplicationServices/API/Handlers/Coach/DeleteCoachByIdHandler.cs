using AutoMapper;
using FootballManager.AplicationServices.API.Domain.Coach;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Commands;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Coach
{
    public class DeleteCoachByIdHandler : IRequestHandler<DeleteCoachByIdRequest, DeleteCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCoachByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteCoachByIdResponse> Handle(DeleteCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachByIdQuery()
            {
                CoachId = request.CoachId
            };
            var coachToDelete = await this.queryExecutor.Execute(query);

            var command = new DeleteCoachByIdCommand()
            {
                Parameter = coachToDelete
            };
            var deletedCoach = await this.commandExecutor.Execute(command);
            var mappedCoach = this.mapper.Map<CoachDTO>(deletedCoach);

            var response = new DeleteCoachByIdResponse()
            {
                Data = mappedCoach
            };
            return response;
        }
    }
}
