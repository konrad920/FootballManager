using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Team
{
    public class GetAllTeamsRequest : IRequest<GetAllTeamsResponse>
    {
        public string? PartOFName { get; set; }
    }
}
