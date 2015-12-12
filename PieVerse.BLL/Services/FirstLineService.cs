using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(FirstLine line)
        {
            _unitOfWork.FirstLineRepository.Create(line);
            _unitOfWork.Save();
        }

        public IEnumerable<FirstLine> Get()
        {
            return _unitOfWork.FirstLineRepository.Get();
        }
    }
}
