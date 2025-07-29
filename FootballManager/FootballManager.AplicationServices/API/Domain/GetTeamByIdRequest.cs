using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class GetTeamByIdRequest : IRequest<GetTeamByIdResponse>
    {
        public int TeamId { get; set; }
    }
}
