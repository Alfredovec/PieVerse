using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<PieverseContext>
    {
        protected override void Seed(PieverseContext context)
        {


            base.Seed(context);
        }
    }
}
