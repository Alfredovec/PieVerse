using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PieVerse.Web.Mappers;

namespace PieVerse.Web.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            PieverseMapper.RegisterMaps();
        }
    }
}