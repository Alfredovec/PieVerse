using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PieVerse.DomainModel.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Nickname { get; set; }

        public ICollection<FirstLine> FirstLines { get; set; }

        public ICollection<Pieverse> Pieverses { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

    }
}
