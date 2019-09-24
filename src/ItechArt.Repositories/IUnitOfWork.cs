using System.Threading.Tasks;

namespace ItechArt.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task SaveAsync();
    }
}