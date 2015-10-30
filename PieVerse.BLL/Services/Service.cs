using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.BLL.Interfaces;

namespace PieVerse.BLL.Services
{
    public class Service : IService
    {
        public IAuthorService AuthorService { get { return new AuthorService(); } }
        public IFirstLineService FirstLineService { get { return new FirstLineService(); } }
        public IPayverseService PayverseService { get { return new PayverseService(); } }
    }
}
