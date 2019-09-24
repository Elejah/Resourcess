using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ItechArt.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        private readonly DbSet<TEntity> _dbSet;


        public Repository(DbContext context)
        {
            _context = context;

            _dbSet = context.Set<TEntity>();
        }


        public void Create(TEntity item)
        {
             _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public Task<TEntity> GetAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}