using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class GetAllTeamsRequest : IRequest<GetAllTeamsResponse>
    {
        public String ?PartOFName { get; set; }
    }
}
