using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class NumberRepository : BaseRepository<RandomNumber>, INumberRepository
    {

        public NumberRepository(TestDbContext context) : base(context)
        {
        }
    }
}
