using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
