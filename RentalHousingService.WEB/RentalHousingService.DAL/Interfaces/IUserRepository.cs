using RentalService.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalHousingService.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> FindUsersByType(int typeUser);
        Task<User> FindUserByLogin(string login);
    }
}
