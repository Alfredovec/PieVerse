using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PieVerse.Web.Models
{
    public class FirstLineViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }
    }
}