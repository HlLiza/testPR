using RentalHousingService.BLL.DTO;
using System.Threading.Tasks;

namespace RentalHousingService.BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        Task<UserDTO> FindUserByLogin(string login);
    }
}
