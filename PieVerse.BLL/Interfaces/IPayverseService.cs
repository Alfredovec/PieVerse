using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Interfaces
{
    public interface IPayverseService
    {
        void Add(Pieverse entry);
        IEnumerable<Pieverse> Get();
    }
}
