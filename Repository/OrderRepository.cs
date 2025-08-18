using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(TestDbContext context) : base(context)
        {
        }

        public Task<List<Order>> GetOrdersByCustomer(int id)
        {
            return _context.Orders.Where(x => x.CustomerId == id).ToListAsync();
        }
    }
}
