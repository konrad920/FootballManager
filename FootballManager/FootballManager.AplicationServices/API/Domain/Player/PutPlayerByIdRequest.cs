using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Player
{
    public class PutPlayerByIdRequest : IRequest<PutPlayerByIdResponse>
    {
        public int PlayerId { get; set; }

        public string? NewFirstName { get; set; }

        public string? NewLastName { get; set; }
    }
}
