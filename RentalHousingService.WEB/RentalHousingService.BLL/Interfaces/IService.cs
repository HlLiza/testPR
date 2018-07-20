using System.Threading.Tasks;

namespace RentalHousingService.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<int?> Add(T entity);
        Task<int?> Delete(T entity);
        Task<int?> Edit(T entity);
        Task<T> FindById(int id);
    }
}
