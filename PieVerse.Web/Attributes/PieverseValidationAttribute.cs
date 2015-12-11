using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PieVerse.Web.Attributes
{
    public class PieverseValidationAttribute : ValidationAttribute
    {
        private static readonly char[] Vowels = new char[10] { 'а', 'е', 'ё', 'и', 'о', 'у', 'э', 'ы', 'ю', 'я' };

        public override bool IsValid(object value)
        {
            string pieverse = value as string;
            bool isLowCase = pieverse.Equals(pieverse.ToLower());
            string[] rows = pieverse.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            bool isThreeRows = rows.Length.Equals(3);
            bool isRightVowels = isThreeRows && rows[0].Count(c => Vowels.Contains(c)) == 8
                                 && rows[1].Count(c => Vowels.Contains(c)) == 9
                                 && rows[2].Count(c => Vowels.Contains(c)) == 8;

            this.ErrorMessage = string.Empty;
            if (!isLowCase)
                this.ErrorMessage += string.Format("Ваше произведение содержит заглавные буквы.{0}", Environment.NewLine);
            if (!isThreeRows)
                this.ErrorMessage += string.Format("В пирожке должно быть 4 строки.{0}", Environment.NewLine);
            if (isThreeRows && !isRightVowels)
                this.ErrorMessage += string.Format("Ваше произведение не соответствует ритму.{0}Придерживайтесь ритма пирожка: 9-8-9-8.{0}У вас вышло 9-{1}-{2}-{3}.",
                    Environment.NewLine, rows[0].Count(c => Vowels.Contains(c)), rows[1].Count(c => Vowels.Contains(c)), rows[2].Count(c => Vowels.Contains(c)));


            return isLowCase
                && isThreeRows
                && isRightVowels;
        }
    }
}