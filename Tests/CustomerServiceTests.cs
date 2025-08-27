namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
    }

    /*
     [TestClass]
    public class CustomerServiceTest
    {
        CustomerService _customerService;
        Mock<ICustomerRepository> _customerRepository;
        Mock<IOrderRepository> _orderRepository;
        Mock<Helper> _helper;

        [TestInitialize]
        public void Initialize()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _orderRepository = new Mock<IOrderRepository>();
            _helper = new Mock<Helper>();

            _customerService = new CustomerService(
                _customerRepository.Object, _orderRepository.Object, _helper.Object);
        }

        [TestMethod]        
        public async Task CanPurchase_InvalidIdUser_Exception()
        {
            int customerId = -1, purchaseValue = 100;
            
            await Assert
                .ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () 
                => await _customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_InvalidPurchaseValue_Exception()
        {
            int customerId = 1, purchaseValue = 0;

            await Assert
                .ThrowsExceptionAsync<ArgumentOutOfRangeException>(async ()
                => await _customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_NonRegisteredCustomerCannotPurchase_Exception()
        {
            int customerId = 999999999, purchaseValue = 50;

            _customerRepository.Setup(x => x.GetByIdAsync(customerId)).ReturnsAsync(value: null);
                        
            await Assert
                .ThrowsExceptionAsync<InvalidOperationException>(async ()
                => await _customerService.CanPurchase(customerId, purchaseValue));
        }

        [TestMethod]
        public async Task CanPurchase_MoreThanOnePurchaseMonth_False()
        {
            int customerId = 1, purchaseValue = 50;

            List<Order> orders = new List<Order>();
            orders.Add(new Order() { CustomerId = 1, OrderDate = DateTime.Now, Value = 10 });
            orders.Add(new Order() { CustomerId = 1, OrderDate = DateTime.Now, Value = 11 });

            _customerRepository
                .Setup(x => x
                .GetByIdAsync(customerId))
                .ReturnsAsync(new Customer() { Id = 1, Name = "Yuri"});

            _orderRepository.Setup(x => x.GetOrdersByCustomer(customerId)).ReturnsAsync(orders);


            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CanPurchase_FirstPurchaseGreaterThan100_False()
        {
            int customerId = 1, purchaseValue = 101;

            List<Order> orders = new List<Order>();
            
            _customerRepository
                .Setup(x => x
                .GetByIdAsync(customerId))
                .ReturnsAsync(new Customer() { Id = 1, Name = "Yuri" });

            _orderRepository.Setup(x => x.GetOrdersByCustomer(customerId)).ReturnsAsync(orders);


            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CanPurchase_PurchaseOnlyWorkingHoursDays_False()
        {
            int customerId = 1, purchaseValue = 50;

            List<Order> orders = new List<Order>();

            _customerRepository
                .Setup(x => x
                .GetByIdAsync(customerId))
                .ReturnsAsync(new Customer() { Id = 1, Name = "Yuri" });

            _orderRepository.Setup(x => x.GetOrdersByCustomer(customerId)).ReturnsAsync(orders);
            _helper.Setup(x => x.IsOutsideWorkingHoursDays()).Returns(true);
            
            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task CanPurchase_PurchaseOnlyWorkingHoursDays_True()
        {
            int customerId = 1, purchaseValue = 50;

            List<Order> orders = new List<Order>();

            _customerRepository
                .Setup(x => x
                .GetByIdAsync(customerId))
                .ReturnsAsync(new Customer() { Id = 1, Name = "Yuri" });

            _orderRepository.Setup(x => x.GetOrdersByCustomer(customerId)).ReturnsAsync(orders);
            _helper.Setup(x => x.IsOutsideWorkingHoursDays()).Returns(false);

            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            Assert.IsTrue(result);
        }
    }
    */
}
