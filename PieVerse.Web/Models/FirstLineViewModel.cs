using System.ComponentModel.DataAnnotations;
using PieVerse.Web.Attributes;

namespace PieVerse.Web.Models
{
    public class FirstLineViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Вы забыли написать строку.")]
        [FirstLineValidation]
        public string Text { get; set; }
    }
}