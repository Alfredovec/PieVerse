using PieVerse.DAL.Interfaces;

namespace PieVerse.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PieverseContext _context;

        public UnitOfWork()
        {
            _context = new PieverseContext();
        }

        public IAuthorRepository AuthorRepository { get { return new AuthorRepository(_context);} }
        public IPieverseRepository PieverseRepository { get { return new PieverseRepository(_context);} }
        public IFirstLineRepository FirstLineRepository { get { return new FirstLineRepository(_context);} }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
