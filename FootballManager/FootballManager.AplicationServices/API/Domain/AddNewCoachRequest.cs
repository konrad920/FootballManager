using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class AddNewCoachRequest : IRequest<AddNewCoachResponse>
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }
        
        public long Salary { get; set; }
    }
}
