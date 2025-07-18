using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            this.CreateMap<AddNewPLayerRequest, Player>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.Salary))
                .ForMember(x => x.TeamId, y => y.MapFrom(z => z.TeamId));

            this.CreateMap<Player, PlayerDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.TeamName, y => y.MapFrom(z => z.Team.Name));
        }
    }
}
