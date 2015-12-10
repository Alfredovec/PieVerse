using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PieVerse.Web.Attributes
{
    public class FirstLineValidationAttribute : ValidationAttribute
    {
        private static readonly char[] Vowels = new char[9] { 'а', 'е', 'ё', 'и', 'о', 'у', 'э', 'ю', 'я' };

        public override bool IsValid(object value)
        {
            string pieverse = value as string;
            bool isLowCase = pieverse.Equals(pieverse.ToLower());
            bool isRightVowels = pieverse.Count(c => Vowels.Contains(c)) == 9;

            this.ErrorMessage = string.Empty;
            if (!isLowCase)
                this.ErrorMessage += string.Format("Ваша строка содержит заглавные буквы.{0}", Environment.NewLine);
            if (!isRightVowels)
                this.ErrorMessage += string.Format("Ваша строка не соответствует ритму.{0}В строке должно быть 9 слогов.{0}У вас вышло {1}.",
                    Environment.NewLine, pieverse.Count(c => Vowels.Contains(c)));


            return isLowCase
                && isRightVowels;
        }
    }
}