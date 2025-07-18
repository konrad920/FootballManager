using System.ComponentModel.DataAnnotations;

namespace FootballManager.DataAccess.Entities
{
    public class Coach : EntityBase
    {
        public Team Team { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public long Salary { get; set; }
    }
}
