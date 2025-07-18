using System.ComponentModel.DataAnnotations;

namespace FootballManager.DataAccess.Entities
{
    public class Team : EntityBase
    {
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string StadiumName { get; set; }
    }
}
