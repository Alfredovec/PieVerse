using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL
{
    public class PieverseContext : DbContext
    {
        public PieverseContext() : base("PieverseContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<FirstLine> FirstLines { get; set; }

        public DbSet<Pieverse> Pieverses { get; set; }
    }
}
