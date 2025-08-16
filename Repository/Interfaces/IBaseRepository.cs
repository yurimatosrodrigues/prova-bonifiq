using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query();
        int Add(T entity);
        Task<ListModel<T>> GetAllPagingAsync(int page, int pageSize);
    }
}
