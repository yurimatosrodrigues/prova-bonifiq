using ProvaPub.Models.ValueObjects;

namespace ProvaPub.Services
{
    public class PaymentService 
    {
        private readonly List<IPayment> _paymentsMethods;

        public PaymentService(IEnumerable<IPayment> paymentMethods)
        {
            _paymentsMethods = paymentMethods.ToList();
        }

        public void Pay(string paymentMethod)
        {
            var method = _paymentsMethods
                .Where(x => x.Name.ToUpper() == paymentMethod.ToUpper())
                .FirstOrDefault();

            if (method == null)
                throw new Exception("Forma de pagamento inválida.");

            method.Pay();
        }
    }
}
