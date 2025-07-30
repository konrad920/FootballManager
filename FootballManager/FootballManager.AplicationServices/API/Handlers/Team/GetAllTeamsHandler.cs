using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Team;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Team
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsRequest, GetAllTeamsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllTeamsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllTeamsQuery()
            {
                PartOfName = request.PartOFName
            };
            var teams = await queryExecutor.Execute(query);
            var mappedTeams = mapper.Map<List<TeamDTO>>(teams);

            var response = new GetAllTeamsResponse()
            {
                Data = mappedTeams
            };
            return response;
        }
    }
}
