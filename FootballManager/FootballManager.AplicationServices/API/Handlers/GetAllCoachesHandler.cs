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

        public GetAllCoachesHandler(IRepository<Coach> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var coaches = repository.GetAll();
            var domainCoaches = coaches.Select(x => new CoachDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            });

            var response = new GetAllCoachesResponse()
            {
                Data = domainCoaches.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
