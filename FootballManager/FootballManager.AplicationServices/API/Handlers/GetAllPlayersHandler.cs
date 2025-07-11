using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersRequest, GetAllPlayersResponse>
    {
        private readonly IRepository<Player> repository;
        private readonly IMapper mapper;

        public GetAllPlayersHandler(IRepository<Player> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = this.repository.GetAll();
            var mappedPLayers = this.mapper.Map<List<PlayerDTO>>(players);

            var response = new GetAllPlayersResponse()
            {
                Data = mappedPLayers
            };

            return Task.FromResult(response);
        }
    }
}
