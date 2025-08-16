namespace ProvaPub.Models.ValueObjects
{
    public interface IPayment
    {
        string Name { get; }
        void Pay();
    }
}
