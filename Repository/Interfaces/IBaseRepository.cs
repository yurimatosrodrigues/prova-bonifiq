namespace ProvaPub.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        int Add(T entity);
    }
}
