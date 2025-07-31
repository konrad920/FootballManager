using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Player
{
    public class DeletePlayerByIdRequest : IRequest<DeletePlayerByIdResponse>
    {
        public int PlayerId { get; set; }
    }
}
