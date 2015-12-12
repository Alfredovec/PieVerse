using AutoMapper;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Models;

namespace PieVerse.Web.Mappers
{
    public class PieverseMapper
    {
        public static void RegisterMaps()
        {
            RegisterSimpleMaps();
        }

        private static void RegisterSimpleMaps()
        {
            Mapper.CreateMap<FirstLine, FirstLineViewModel>();
            Mapper.CreateMap<FirstLineViewModel, FirstLine>();

            Mapper.CreateMap<Pieverse, PieverseViewModel>()
                .ForMember(p => p.FirstLine, m => m.MapFrom(pvm => pvm.FirstLine));
            Mapper.CreateMap<PieverseViewModel, Pieverse>()
                .ForMember(pvm => pvm.FirstLine, m => m.MapFrom(p => p.FirstLine));
        }
    }
}