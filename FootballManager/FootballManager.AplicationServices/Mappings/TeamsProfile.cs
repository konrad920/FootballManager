using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            this.CreateMap<Team, TeamDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.StadiumName, y => y.MapFrom(z => z.StadiumName));
        }
    }
}
