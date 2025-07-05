using System.ComponentModel.DataAnnotations;

namespace FootballManager.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
