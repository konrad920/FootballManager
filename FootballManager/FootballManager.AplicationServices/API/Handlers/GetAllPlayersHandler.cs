using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersRequest, GetAllPlayersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllPlayersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllPlayersQuery();
            var players = await this.queryExecutor.Execute(query);
            var mappedPLayers = this.mapper.Map<List<PlayerDTO>>(players);

            var response = new GetAllPlayersResponse()
            {
                Data = mappedPLayers
            };

            return response;
        }
    }
}
