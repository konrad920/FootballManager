using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Player
{
    public class GetAllPlayersRequest : IRequest<GetAllPlayersResponse>
    {
        public string ?Position { get; set; }
    }
}
