using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Team
{
    public class GetTeamByIdRequest : IRequest<GetTeamByIdResponse>
    {
        public int TeamId { get; set; }
    }
}
