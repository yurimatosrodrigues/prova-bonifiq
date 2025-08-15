using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class NumberRepository : BaseRepository<RandomNumber>, INumberRepository
    {

        public NumberRepository(TestDbContext context) : base(context)
        {
        }

        public int CountNumbers()
        {
            return _context.Numbers.Count();
        }

        public bool NumberExists(int number)
        {
            var value = _context.Numbers.Count(x => x.Number == number);

            if (value > 0) return true;
            return false;            
        }
    }
}
