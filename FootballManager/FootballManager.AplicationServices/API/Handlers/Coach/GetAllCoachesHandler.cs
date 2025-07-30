using AutoMapper;
using FootballManager.AplicationServices.API.Domain.Coach;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Coach
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllCoachesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllCoachesQuery();
            var coaches = await queryExecutor.Execute(query);
            var mappedCoaches = mapper.Map<List<CoachDTO>>(coaches);

            var response = new GetAllCoachesResponse()
            {
                Data = mappedCoaches
            };
            return response;
        }
    }
}
