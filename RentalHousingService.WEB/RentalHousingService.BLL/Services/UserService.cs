using AutoMapper;
using RentalHousingService.BLL.DTO;
using RentalHousingService.BLL.Interfaces;
using RentalHousingService.DAL.Interfaces;
using RentalHousingService.DAL.Repositories;
using RentalService.DAL.Models;
using System.Threading.Tasks;

namespace RentalHousingService.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<UserDTO> FindUserByLogin(string login)
        {
            User user = await _unitOfWork.UserRepository.FindUserByLogin(login);
            return Mapper.Map<User, UserDTO>(user);
        }

        public async Task<int?> Add(UserDTO entity)
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

            User user = Mapper.Map<UserDTO, User>(entity);
            return await _unitOfWork.UserRepository.Add(user);
        }


        public Task<int?> Delete(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<int?> Edit(UserDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
