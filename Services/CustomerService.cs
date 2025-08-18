using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services.Interfaces;
using ProvaPub.Utils;

namespace ProvaPub.Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IOrderRepository _orderRepository;
        Helper _helper;

        int pageSize = 10;               

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository, Helper helper)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _helper = helper;
        }

        public async Task<CustomerList> ListCustomers(int page)
        {
            var customerList = await _customerRepository.GetAllPagingAsync(page, pageSize);
            return new CustomerList()
            {
                Items = customerList.Items,
                TotalCount = customerList.TotalCount,
                HasNext = customerList.HasNext
            };
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var orders = await _orderRepository.GetOrdersByCustomer(customerId);
            var ordersInThisMonth = orders.Count(x => x.OrderDate >= baseDate);

            if (ordersInThisMonth > 0)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00            
            var haveBoughtBefore = orders.Count;
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            //Business Rule: A customer can purchases only during business hours and working days
            if (_helper.IsOutsideWorkingHoursDays())
                return false;

            return true;
        }
    }
}
