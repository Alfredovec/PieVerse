using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Attributes;

namespace PieVerse.Web.Models
{
    public class PieverseCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [PieverseValidation(ErrorMessage = "Ваше произведение, конечно, прекрасно, но это не пирожок")]
        public string Body { get; set; }

        public FirstLineViewModel FirstLine;
    }
}