using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Team
{
    public class DeleteTeamByIdRequest : IRequest<DeleteTeamByIdResponse>
    {
        public int TeamId { get; set; }
    }
}
