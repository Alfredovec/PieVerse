using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PieVerse.Web.Attributes;

namespace PieVerse.Web.Models
{
    public class PieverseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Вы забыли написать пирожок.")]
        [PieverseValidation]
        public string Body { get; set; }

        public FirstLineViewModel FirstLine { get; set; }
    }
}