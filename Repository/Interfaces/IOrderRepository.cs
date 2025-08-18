using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrdersByCustomer(int id);
    }
}
