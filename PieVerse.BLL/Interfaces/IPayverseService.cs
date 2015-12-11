﻿using System.Collections.Generic;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Interfaces
{
    public interface IPayverseService
    {
        void Add(Pieverse entry);
        IEnumerable<Pieverse> Get();
        void Delete(int id);
    }
}
