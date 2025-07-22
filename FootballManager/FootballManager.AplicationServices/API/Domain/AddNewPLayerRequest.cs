using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class AddNewPlayerRequest : IRequest<AddNewPlayerResponse>
    {
        private PlayerPositions position;

        public int TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Position { get; set; }

        public long Salary { get; set; }
    }
}
