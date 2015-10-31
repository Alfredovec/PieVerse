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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly PieverseContext _context;

        public AuthorRepository(PieverseContext context)
        {
            _context = context;
        }

        public IQueryable<Author> Get()
        {
            return _context.Authors;
        }

        public void Create(Author entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Author entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Author entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
