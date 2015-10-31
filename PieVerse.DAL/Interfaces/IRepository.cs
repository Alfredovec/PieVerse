using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
