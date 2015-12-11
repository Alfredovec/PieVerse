using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PieVerse.DomainModel.Entities
{
    public class FirstLine
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Text { get; set; }

        // TODO @Kondrat implement other props

        public virtual Author Author { get; set; }

        public virtual ICollection<Pieverse> Pieverses { get; set; }
    }
}
