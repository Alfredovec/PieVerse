using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }

        IPieverseRepository PieverseRepository { get; }

        IFirstLineRepository FirstLineRepository { get; }

        void Save();
    }
}
