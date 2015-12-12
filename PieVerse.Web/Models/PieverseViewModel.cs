using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string AuthorName { get; set; }

        public DateTime? AddingTime { get; set; }

        public FirstLineViewModel FirstLine { get; set; }

        public IEnumerable<string> AllLines { get; set; }

        public int LikesCount { get; set; }

        public bool IsLiked { get; set; }
    }
}