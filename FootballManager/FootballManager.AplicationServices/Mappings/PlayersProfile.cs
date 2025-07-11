using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            this.CreateMap<Player, PlayerDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.position, y => y.MapFrom(z => z.Position));
        }
    }
}
