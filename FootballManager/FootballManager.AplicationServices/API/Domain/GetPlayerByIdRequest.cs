using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class GetPlayerByIdRequest : IRequest<GetPlayerByIdResponse>
    {
        public int PlayerId { get; set; }
    }
}
