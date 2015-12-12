using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DomainModel.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public Author Author { get; set; }

        public Pieverse Pieverse { get; set; }
    }
}
