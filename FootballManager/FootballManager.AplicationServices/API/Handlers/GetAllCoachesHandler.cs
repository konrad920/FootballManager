using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IRepository<Coach> repository;
        private readonly IMapper mapper;

        public GetAllCoachesHandler(IRepository<Coach> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var coaches = await repository.GetAll();
            var mappedCoaches = this.mapper.Map<List<CoachDTO>>(coaches);

            var response = new GetAllCoachesResponse()
            {
                Data = mappedCoaches
            };
            return response;
        }
    }
}
