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

        public GetAllPlayersHandler(IRepository<Player> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = this.repository.GetAll();
            /*var domainPlayers = players.Select(x => new Domain.ModelsDTO.PlayerDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                position = x.Position
            });
            */

            var domainPlayers = new List<PlayerDTO>();
            foreach (var player in players)
            {
                domainPlayers.Add(new PlayerDTO()
                {
                    Id = player.Id,
                    FirstName = player.FirstName,
                    position = player.Position
                });
            }
            var response = new GetAllPlayersResponse()
            {
                Data = domainPlayers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
