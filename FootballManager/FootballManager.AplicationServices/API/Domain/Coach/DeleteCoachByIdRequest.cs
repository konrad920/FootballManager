using MediatR;

namespace FootballManager.AplicationServices.API.Domain.Coach
{
    public class DeleteCoachByIdRequest : IRequest<DeleteCoachByIdResponse>
    {
        public int CoachId { get; set; }
    }
}
