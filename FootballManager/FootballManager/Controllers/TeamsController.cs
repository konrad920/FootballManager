using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IRepository<Team> repository;

        public TeamsController(IRepository<Team> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("AllTeams")]
        public IEnumerable<Team> GetAllTeams()
        {
            return repository.GetAll();
        }
    }
}
