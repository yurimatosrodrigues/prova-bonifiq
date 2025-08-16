namespace ProvaPub.Models.ValueObjects
{
    public class CreditCard : IPayment
    {
        public string Name => "creditcard";

        public void Pay()
        {
            System.Diagnostics.Debug.WriteLine("Credit Card");
        }
    }
}
