using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
