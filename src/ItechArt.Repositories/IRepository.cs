using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItechArt.Repositories
{
    public interface IRepository<T>
    {
        void Create(T item);

        void Update(T item);

        void Delete(T item);

        Task<T> GetAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();
    }
}