using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using PieVerse.BLL.Interfaces;
using PieVerse.DAL.Interfaces;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Services
{
    public class PayverseService : IPayverseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayverseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Pieverse entry, string authorName)
        {
            var author = _unitOfWork.AuthorRepository.Get().First(a => a.Nickname.Equals(authorName));
            var firstLine = _unitOfWork.FirstLineRepository.Get().First(l => l.Text.Equals(entry.FirstLine.Text));
            entry.Author = author;
            entry.FirstLine = firstLine;
            _unitOfWork.PieverseRepository.Create(entry);
            _unitOfWork.Save();
        }

        public IEnumerable<Pieverse> Get()
        {
            return _unitOfWork.PieverseRepository.Get();
        }

        public void Delete(int id)
        {
            var entry = _unitOfWork.PieverseRepository.Get().Single(p => p.Id.Equals(id));
            _unitOfWork.PieverseRepository.Delete(entry);
            _unitOfWork.Save();
        }

        public Pieverse GetById(int id)
        {
            return _unitOfWork.PieverseRepository.Get().Single(p => p.Id.Equals(id));
        }
    }
}
