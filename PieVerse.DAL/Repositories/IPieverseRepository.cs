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
    public class PieverseRepository : IPieverseRepository
    {
        private readonly PieverseContext _context;

        public PieverseRepository(PieverseContext context)
        {
            _context = context;
        }
        public IQueryable<Pieverse> Get()
        {
            return _context.Pieverses;
        }

        public void Create(Pieverse entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(Pieverse entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Pieverse entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
