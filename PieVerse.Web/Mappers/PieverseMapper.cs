using System;
using System.Web.Mvc;
using AutoMapper;
using PieVerse.BLL.Interfaces;
using PieVerse.DomainModel.Entities;
using PieVerse.Web.Models;
using WebMatrix.WebData;

namespace PieVerse.Web.Mappers
{
    public class PieverseMapper
    {
        private static IService _service;

        public static void RegisterMaps()
        {
            _service = DependencyResolver.Current.GetService<IService>();
            RegisterSimpleMaps();
        }

        private static void RegisterSimpleMaps()
        {
            Mapper.CreateMap<FirstLine, FirstLineViewModel>();
            Mapper.CreateMap<FirstLineViewModel, FirstLine>();

            Mapper.CreateMap<Pieverse, PieverseViewModel>()
                .ForMember(pvm => pvm.FirstLine, m => m.MapFrom(p => p.FirstLine))
                .ForMember(pvm => pvm.LikesCount, m => m.MapFrom(p => p.Likes.Count))
                .ForMember(pvm => pvm.AuthorName, m => m.MapFrom(p => p.Author.Nickname))
                .ForMember(pvm => pvm.IsLiked, m => m.MapFrom(p => _service.LikeService.IsLikedBy(WebSecurity.CurrentUserName, p.Id)));
            Mapper.CreateMap<PieverseViewModel, Pieverse>()
                .ForMember(p => p.FirstLine, m => m.MapFrom(pvm => pvm.FirstLine))
                .ForMember(p => p.AddingTime, m => m.MapFrom(pvm => DateTime.UtcNow));

            Mapper.CreateMap<RegisterModel, Author>()
                .ForMember(a => a.Nickname, m => m.MapFrom(rm => rm.UserName));

        }
    }
}