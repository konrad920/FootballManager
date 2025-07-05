using FootballManager.DataAccess;
using FootballManager.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IRepository<Team> teamRepository;

        public TeamsController(IRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("AllTeams")]
        public IEnumerable<Team> GetAllTeams()
        {
            return this.teamRepository.GetAll();
        }

        [HttpGet]
        [Route("{teamId}")]
        public Team GetTeam(int teamId)
        {
            return this.teamRepository.GetById(teamId);
        }
    }
}
