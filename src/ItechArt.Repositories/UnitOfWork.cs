using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ItechArt.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork 
    {
        private readonly DbContext _db;


        public UnitOfWork(DbContext db)
        {
            _db = db;
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}