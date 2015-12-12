using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.BLL.Interfaces;
using PieVerse.DAL.Interfaces;

namespace PieVerse.BLL.Services
{
    public class Service : IService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IAuthorService AuthorService { get { return new AuthorService(_unitOfWork); } }
        public IFirstLineService FirstLineService { get { return new FirstLineService(_unitOfWork); } }
        public IPayverseService PayverseService { get { return new PayverseService(_unitOfWork); } }
        public ILikeService LikeService { get { return new LikeService(_unitOfWork); } }
    }
}
