using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PieVerse.DomainModel.Entities
{
    public class Pieverse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime AddingTime { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual FirstLine FirstLine { get; set; }

        public virtual Author Author { get; set; }
    }
}
