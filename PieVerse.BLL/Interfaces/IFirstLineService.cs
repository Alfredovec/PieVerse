using System.Collections.Generic;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Interfaces
{
    public interface IFirstLineService
    {
        FirstLine GetRandomFirstLine();
        void Add(FirstLine line);
        IEnumerable<FirstLine> Get();
    }
}
