using AutoMapper;
using FootballManager.AplicationServices.API.Domain.ModelsDTO;
using FootballManager.DataAccess.Entities;

namespace FootballManager.AplicationServices.Mappings
{
    public class CoachesProfile : Profile
    {
        public CoachesProfile()
        {
            this.CreateMap<Coach, CoachDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
