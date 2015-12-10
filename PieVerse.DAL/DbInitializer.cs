using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<PieverseContext>
    {
        protected override void Seed(PieverseContext context)
        {
            var admin = new Author(){ Nickname = "Admin" };
            context.Authors.Add(admin);

            string[] lines = new string[]
            {
                "производители одежды",
                "а где тут руль спросил гагарин",
                "в приморье граждан опросили",
                "я в следующей жизни стану",
                "бесперспективна и уныла",
                "мы побываем в уникальных",
                "так грациозно и изящно",
                "опять довёл до слёз татьяну",
                "завыть бы волком у дороги",
                "вы говорили я ничтожен",
                "я часто думал кем я стану",
                "жене машину покупаю",
                "по независимым подсчетам",
                "когда я думаю о вечном",
                "впервые на странице этой",
                "с тобой никто не согласится",
                "вот золотая середина",
                "пообещал поправив китель"
            };

            for (int i = 0; i < lines.Length; i++)
            {
                context.FirstLines.Add(new FirstLine()
                {
                    Author = admin,
                    Body = lines[i]
                });
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
