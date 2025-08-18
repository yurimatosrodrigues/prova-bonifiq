using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
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

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ListModel<T>> GetAllPagingAsync(int page, int pageSize)
        {
            int countItems = await Query().CountAsync();
            bool hasNext = (page * pageSize) < countItems;
            
            var items = await _context.Set<T>().AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new ListModel<T>()
            {
                Items = items,
                TotalCount = countItems,
                HasNext = hasNext
            };
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
