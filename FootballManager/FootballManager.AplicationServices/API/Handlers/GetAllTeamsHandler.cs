using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using MediatR;

namespace FootballManager.AplicationServices.API.Handlers
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsRequest, GetAllTeamsResponse>
    {
        private readonly IRepository<Team> repository;
        private readonly IMapper mapper;

        public GetAllTeamsHandler(IRepository<Team> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = repository.GetAll();
            var mappedTeams = this.mapper.Map<List<TeamDTO>>(teams);

            var response = new GetAllTeamsResponse()
            {
                Data = mappedTeams
            };
            return Task.FromResult(response);
        }
    }
}
