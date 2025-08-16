namespace ProvaPub.Models.ValueObjects
{
    public class Pix : IPayment
    {
        public string Name => "pix";

        public void Pay()
        {
            System.Diagnostics.Debug.WriteLine("Pix");
        }
    }
}
