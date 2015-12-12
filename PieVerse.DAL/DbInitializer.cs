using System.Data.Entity;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<PieverseContext>
    {
        protected override void Seed(PieverseContext context)
        {
            var admin = new Author() { Nickname = "Admin" };
            var user = new Author() { Nickname = "User" };
            context.Authors.Add(admin);
            context.Authors.Add(user);

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

            foreach (string line in lines)
            {
                context.FirstLines.Add(new FirstLine()
                {
                    Author = admin,
                    Text = line
                });
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
