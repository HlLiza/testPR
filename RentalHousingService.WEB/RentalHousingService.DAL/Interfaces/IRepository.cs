using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalHousingService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int?> Add(T entity);
        Task<int?> Delete(T entity);
        Task<int?> Edit(T entity);
        Task<T> FindById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
