using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Player
{
    public class AddNewPlayerRequest : IRequest<AddNewPlayerResponse>
    {
        public int TeamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ?Position { get; set; }

        public long Salary { get; set; }
    }
}
