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

        public IAuthorService AuthorService { get { return new AuthorService(); } }
        public IFirstLineService FirstLineService { get { return new FirstLineService(_unitOfWork); } }
        public IPayverseService PayverseService { get { return new PayverseService(_unitOfWork); } }
    }
}
