using System.Linq;
using PieVerse.BLL.Interfaces;
using PieVerse.DAL.Interfaces;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Create(author);
            _unitOfWork.Save();
        }

        public Author GetAuthor(string userName)
        {
            return _unitOfWork.AuthorRepository.Get().Single(a => a.Nickname.Equals(userName));
        }
    }
}
