using AutoMapper;
using RentalHousingService.BLL.DTO;
using RentalService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHousingService.BLL.Mapping
{
    public static class UserDTOMapping
    {
        public static void MapUserToUserDTO()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserDTO, User>()
                .ForMember("Id", opt => opt.MapFrom(src => src.Id))
                .ForMember("Login", opt => opt.MapFrom(src => src.Login))
                .ForMember("Salt", opt => opt.MapFrom(src => src.Salt))
                .ForMember("PasswordHash", opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember("TypeUser", opt => opt.MapFrom(src => src.TypeUser))
                .ForMember("Name", opt => opt.MapFrom(src => src.Name))
                .ForMember("Surname", opt => opt.MapFrom(src => src.Surname))
                .ForMember("Language", opt => opt.MapFrom(src => src.Language));

            });

        }
    }
}
