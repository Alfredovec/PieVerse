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
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Like(int pieverseId, string userName)
        {
            int change = 0;
            var author = _unitOfWork.AuthorRepository.Get().Single(a => a.Nickname.Equals(userName));
            var pieverse = _unitOfWork.PieverseRepository.Get().Single(p => p.Id.Equals(pieverseId));

            var like =
                _unitOfWork.LikeRepository.Get()
                    .SingleOrDefault(l => l.Author.Id.Equals(author.Id) && l.Pieverse.Id.Equals(pieverse.Id));
            if (like == null)
            {
                _unitOfWork.LikeRepository.Create(new Like() { Author = author, Pieverse = pieverse });
            }
            else
            {
                _unitOfWork.LikeRepository.Delete(like);
            }
            _unitOfWork.Save();
            return _unitOfWork.LikeRepository.Get().Count(l => l.Pieverse.Id.Equals(pieverseId));
        }

        public bool IsLikedBy(string userName, int pieverseId)
        {
            return _unitOfWork.LikeRepository.Get()
                .Any(l => l.Author.Nickname.Equals(userName) && l.Pieverse.Id.Equals(pieverseId));
        }

        public void DeleteLikesOf(int pieverseId)
        {
            var pieverse = _unitOfWork.PieverseRepository.Get().Single(p => p.Id.Equals(pieverseId));
            foreach (var like in pieverse.Likes)
            {
                _unitOfWork.LikeRepository.Delete(like);
            }
            _unitOfWork.Save();
        }
    }
}
