using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DomainModel.Entities
{
    public class FirstLine
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Body { get; set; }

        // TODO @Kondrat implement other props

        public virtual Author Author { get; set; }

        public virtual ICollection<Pieverse> Pieverses { get; set; }
    }
}
