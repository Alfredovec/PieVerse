using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DomainModel.Entities
{
    public class Pieverse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        // TODO @Kondrat implement other props

        public virtual FirstLine FirstLine { get; set; }

        public virtual Author Author { get; set; }
    }
}
