using System.Collections.Generic;
using System.Linq;
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

        public void Add(Pieverse entry)
        {
            _unitOfWork.PieverseRepository.Create(entry);
            _unitOfWork.Save();
        }

        public IEnumerable<Pieverse> Get()
        {
            return _unitOfWork.PieverseRepository.Get();
        }

        public void Delete(int id)
        {
            var entry = _unitOfWork.PieverseRepository.Get().First(p => p.Id.Equals(id));
            _unitOfWork.PieverseRepository.Delete(entry);
            _unitOfWork.Save();
        }
    }
}
