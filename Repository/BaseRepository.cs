using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected readonly TestDbContext _context;
        public BaseRepository(TestDbContext context)
        {
            _context = context;
        }

        public int Add(T entity)
        {
            _context.Add(entity);
            var saved = _context.SaveChanges();

            return saved;
        }
    }
}
