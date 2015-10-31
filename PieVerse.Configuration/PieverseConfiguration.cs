using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using PieVerse.BLL.Interfaces;
using PieVerse.BLL.Services;
using PieVerse.DAL.Interfaces;
using PieVerse.DAL.Repositories;

namespace PieVerse.Configuration
{
    public class PieverseConfiguration
    {
        public static void RegisterInjection(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IService>().To<Service>();
        }
    }
}
