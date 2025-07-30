using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Coach
{
    public class PutCoachByIdRequest : IRequest<PutCoachByIdResponse>
    {
        public int CoachId { get; set; }

        public string? NewFirstName { get; set; }

        public long NewSalary { get; set; }
    }
}
