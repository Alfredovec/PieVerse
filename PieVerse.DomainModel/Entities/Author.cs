using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string Nickname { get; set; }

        public ICollection<FirstLine> FirstLines { get; set; }

        public ICollection<Pieverse> Pieverses { get; set; } 

    }
}
