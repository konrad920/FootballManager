using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Team
{
    public class PutTeamByIdRequest : IRequest<PutTeamByIdResponse>
    {
        public int TeamId { get; set; }

        public string? NewName { get; set; }
    }
}
