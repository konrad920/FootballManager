using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Team;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Team
{
    public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdRequest, GetTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetTeamByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetTeamByIdResponse> Handle(GetTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.TeamId
            };
            var teamFromDB = await queryExecutor.Execute(query);
            var mappedTeam = mapper.Map<TeamDTO>(teamFromDB);

            var response = new GetTeamByIdResponse()
            {
                Data = mappedTeam,
            };
            return response;
        }
    }
}
