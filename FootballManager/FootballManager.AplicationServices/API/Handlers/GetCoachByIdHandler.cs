using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.CQRS;
using FootballManager.DataAccess.CQRS.Queries;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class GetCoachByIdHandler : IRequestHandler<GetCoachByIdRequest, GetCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCoachByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCoachByIdResponse> Handle(GetCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachByIdQuery()
            {
                CoachId = request.CoachId
            };
            var coachFromDB = await this.queryExecutor.Execute(query);
            var mappedCoach = this.mapper.Map<CoachDTO>(coachFromDB);

            var response = new GetCoachByIdResponse()
            {
                Data = mappedCoach
            };
            return response;
        }
    }
}
