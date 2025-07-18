using AutoMapper;
using FootballManager.AplicationServices.API.Domain;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class CoachesProfile : Profile
    {
        public CoachesProfile()
        {
            this.CreateMap<AddNewCoachRequest, Coach>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.Salary));

            this.CreateMap<Coach, CoachDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.TeamName, y => y.MapFrom(z => z.Team.Name));
        }
    }
}
