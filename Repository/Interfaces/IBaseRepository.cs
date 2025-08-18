using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query();
        int Add(T entity);
        Task<T> AddAsync(T entity);
        Task<ListModel<T>> GetAllPagingAsync(int page, int pageSize);
        Task<T> GetByIdAsync(int id);
    }
}
