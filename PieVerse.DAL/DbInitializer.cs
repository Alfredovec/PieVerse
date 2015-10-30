using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieVerse.DomainModel.Entities;

namespace PieVerse.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<PieverseContext>
    {
        protected override void Seed(PieverseContext context)
        {
            var admin = new Author(){ Nickname = "Admin" };
            context.Authors.Add(admin);

            context.FirstLines.Add(new FirstLine()
            {
                Author = admin,
                Body = "скажи ка дядя ведь не даром"
            });

            context.FirstLines.Add(new FirstLine()
            {
                Author = admin,
                Body = "а где тут руль спросил гагарин"
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
