using System.ComponentModel.DataAnnotations;

namespace FootballManager.DataAccess.Entities
{
    public class Player : EntityBase
    {
        public List<Team> Teams { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public PlayerPositions Position { get; set; }

        public long Salary { get; set; }
    }
}
