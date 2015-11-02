using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PieVerse.DomainModel.Entities;

namespace PieVerse.Web.Models
{
    public class PieverseCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        public FirstLine FirstLine;
    }
}