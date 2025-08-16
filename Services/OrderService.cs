using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services.Interfaces;
using ProvaPub.Utils;

namespace ProvaPub.Services
{
	public class OrderService : IOrderService
	{       
        IOrderRepository _orderRepository;
        PaymentService _paymentService;

        public OrderService(IOrderRepository orderRepository, PaymentService paymentService)
        {
            _orderRepository = orderRepository;
            _paymentService = paymentService;            
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
            _paymentService.Pay(paymentMethod);

			return await InsertOrder(new Order()
            {
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow
            });
		}

		public async Task<Order> InsertOrder(Order order)
        {            
            var result = await _orderRepository.AddAsync(order);

            result.OrderDate = DateUtil.ConvertFromUTCToBrazilianTimeZone(result.OrderDate);
            
            return result;
        }
	}
}
