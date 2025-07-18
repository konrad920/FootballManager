using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.API.Domain.ModelsDTO
{
    public class CoachDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TeamName { get; set; }

        //public Team Team { get; set; }

        //public string TeamName
        //{
        //    get
        //    {
        //        return Team.Name;
        //    }
        //    set
        //    {
        //        if (Team.Name.Length == 12)
        //        {
        //            TeamName = value;
        //        }
        //    }
        //}
    }
}
