using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Coach
{
    public class AddNewCoachRequest : IRequest<AddNewCoachResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public long Salary { get; set; }
    }
}
