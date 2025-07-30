using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Coach
{
    public class GetCoachByIdRequest : IRequest<GetCoachByIdResponse>
    {
        public int CoachId { get; set; }
    }
}
