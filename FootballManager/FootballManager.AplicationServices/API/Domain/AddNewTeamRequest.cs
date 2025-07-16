using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class AddNewTeamRequest : IRequest<AddNewTeamResponse>
    {
        public String Name { get; set; }

        public string StadiumName { get; set; }

        public int CoachId { get; set; }
    }
}
