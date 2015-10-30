using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DomainModel.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        // TODO @Kondrat implement other props

        public ICollection<FirstLine> FirstLines { get; set; }

        public ICollection<Pieverse> Pieverses { get; set; } 

    }
}
