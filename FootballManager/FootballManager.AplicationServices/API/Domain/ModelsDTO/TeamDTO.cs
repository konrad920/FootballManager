namespace FootballManager.AplicationServices.API.Domain.ModelsDTO
{
    public class TeamDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StadiumName { get; set; }

        public int CoachId { get; set; }

        public List<PlayerDTO> PlayersDTO { get; set; }
    }
}
