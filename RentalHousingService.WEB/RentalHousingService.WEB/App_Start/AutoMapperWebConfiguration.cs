using AutoMapper;
using RentalHousingService.BLL.DTO;
using RentalHousingService.WEB.Models;

namespace RentalHousingService.WEB.App_Start
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, UserDTO>()
                    .ForMember("Login", opt => opt.MapFrom(src => src.Login))
                    .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                    .ForMember("Surname", opt => opt.MapFrom(src => src.Surname))
                    .ForMember("Language", opt => opt.MapFrom(src => src.Language))
                    .ForMember("TypeUser", opt => opt.MapFrom(src => src.TypeUser));

            });
        }
    }
}