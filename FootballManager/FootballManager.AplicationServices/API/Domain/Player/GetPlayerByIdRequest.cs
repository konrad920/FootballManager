using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Player
{
    public class GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
    {
        public int PlayerId { get; set; }
    }
}
