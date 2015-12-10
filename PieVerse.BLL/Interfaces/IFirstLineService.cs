using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Interfaces
{
    public interface IFirstLineService
    {
        FirstLine GetRandomFirstLine();
        void Add(FirstLine line);
    }
}
