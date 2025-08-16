namespace ProvaPub.Models.ValueObjects
{
    public class Paypal : IPayment
    {
        public string Name => "paypal";

        public void Pay()
        {
            System.Diagnostics.Debug.WriteLine("Paypal");
        }
    }
}
