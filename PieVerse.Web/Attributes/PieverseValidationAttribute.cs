using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PieVerse.Web.Attributes
{
    public class PieverseValidationAttribute : ValidationAttribute
    {
        private static readonly char[] Vowels = new char[9] { 'а', 'е', 'ё', 'и', 'о', 'у', 'э', 'ю', 'я' };

        public override bool IsValid(object value)
        {
            string pieverse = value as string;
            bool isLowCase = pieverse.Equals(pieverse.ToLower());
            string[] rows = pieverse.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            bool isThreeRows = rows.Length.Equals(3);
            bool isRightVowels = rows[0].Count(c => Vowels.Contains(c)) == 8
                                 && rows[1].Count(c => Vowels.Contains(c)) == 9
                                 && rows[1].Count(c => Vowels.Contains(c)) == 8;
            return isLowCase
                && isThreeRows
                && isRightVowels
                && base.IsValid(value);
        }
    }
}