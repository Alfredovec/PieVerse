using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.BLL.Interfaces;
using PieVerse.DAL.Interfaces;
using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Services
{
    public class FirstLineService : IFirstLineService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FirstLineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FirstLine GetRandomFirstLine()
        {
            Random random = new Random();
            var firstLines = _unitOfWork.FirstLineRepository.Get().ToList();
            return firstLines.ElementAt(random.Next(firstLines.Count()));
        }
    }
}
