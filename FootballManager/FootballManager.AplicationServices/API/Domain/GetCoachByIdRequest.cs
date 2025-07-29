using MediatR;

namespace FootballManager.AplicationServices.API.Domain
{
    public class GetCoachByIdRequest : IRequest<GetCoachByIdResponse>
    {
        public int CoachId { get; set; }
    }
}
