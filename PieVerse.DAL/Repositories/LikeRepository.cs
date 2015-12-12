using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DAL.Interfaces;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly PieverseContext _context;

        public LikeRepository(PieverseContext context)
        {
            _context = context;
        }

        public IQueryable<Like> Get()
        {
            return _context.Likes;
        }

        public void Create(Like entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Like entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Like entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
