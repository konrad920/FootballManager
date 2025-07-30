using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Player;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Player
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
            var query = new GetAllPlayersQuery()
            {
                Position = request.Position
            };
            var players = await queryExecutor.Execute(query);
            var mappedPLayers = mapper.Map<List<PlayerDTO>>(players);

            var response = new GetAllPlayersResponse()
            {
                Data = mappedPLayers
            };

            return response;
        }
    }
}
