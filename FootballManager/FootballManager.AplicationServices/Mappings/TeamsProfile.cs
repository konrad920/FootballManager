using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            this.CreateMap<AddNewTeamRequest, Team>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.StadiumName, y => y.MapFrom(z => z.StadiumName))
                .ForMember(x => x.CoachId, y => y.MapFrom(z => z.CoachId));

            this.CreateMap<Team, TeamDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.StadiumName, y => y.MapFrom(z => z.StadiumName))
                .ForMember(x => x.CoachId, y => y.MapFrom(z => z.CoachId))
                .ForMember(x => x.PlayersDTO, y => y.MapFrom(z => z.Players));
        }
    }
}
