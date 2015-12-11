using System.Linq;

namespace PieVerse.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
