using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Attributes;

namespace PieVerse.Web.Models
{
    public class FirstLineViewModel
    {
        [Key]
        public int Id { get; set; }

        [FirstLineValidation]
        public string Body { get; set; }
    }
}