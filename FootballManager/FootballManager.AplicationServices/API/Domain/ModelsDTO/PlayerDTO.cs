using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.API.Domain.ModelsDTO
{
    public class PlayerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Position { get; set; }

        public string TeamName { get; set; }

    }
}
