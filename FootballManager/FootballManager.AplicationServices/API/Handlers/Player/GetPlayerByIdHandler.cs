using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.AplicationServices.API.Domain.Player;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers.Player
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlayerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery 
            { 
                PlayerId = request.PlayerId 
            };
            var playerFromDB = await queryExecutor.Execute(query);
            var mappedPlayer = mapper.Map<PlayerDTO>(playerFromDB);

            var response = new GetPlayerByIdResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
