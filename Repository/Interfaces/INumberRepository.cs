using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface INumberRepository : IBaseRepository<RandomNumber>
    {
        bool NumberExists(int number);
        int CountNumbers();
    }
}
