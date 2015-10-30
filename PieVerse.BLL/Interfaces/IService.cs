using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.BLL.Interfaces
{
    public interface IService
    {
        IAuthorService AuthorService { get; }

        IFirstLineService FirstLineService { get; }

        IPayverseService PayverseService { get; }
    }
}
