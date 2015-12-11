using System.Data.Entity;
using System.Linq;
using PieVerse.DAL.Interfaces;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL.Repositories
{
    public class FirstLineRepository : IFirstLineRepository
    {
        private readonly PieverseContext _context;

        public FirstLineRepository(PieverseContext context)
        {
            _context = context;
        }
        public IQueryable<FirstLine> Get()
        {
            return _context.FirstLines;
        }

        public void Create(FirstLine entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(FirstLine entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(FirstLine entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
