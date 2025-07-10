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

        public GetAllTeamsHandler(IRepository<Team> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllTeamsResponse> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
        {
            var teams = repository.GetAll();

            var domainTeams = teams.Select(x => new TeamDTO
            {
                Id = x.Id,
                Name = x.Name,
                StadiumName = x.StadiumName
            });

            var response = new GetAllTeamsResponse()
            {
                Data = domainTeams.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
