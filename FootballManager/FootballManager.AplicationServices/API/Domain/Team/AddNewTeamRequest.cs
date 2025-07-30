using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Team
{
    public class AddNewTeamRequest : IRequest<AddNewTeamResponse>
    {
        public string Name { get; set; }

        public string StadiumName { get; set; }

        public int CoachId { get; set; }
    }
}
