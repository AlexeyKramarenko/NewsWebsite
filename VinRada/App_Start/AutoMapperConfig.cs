using AutoMapper;
using BLL.DTO;
using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinRada.ViewModel;

namespace VinRada.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<ArticleViewModel, ArticleDTO>()
                .ForMember(d => d.Title, vm => vm.MapFrom(m => m.Title))
                .ForMember(d => d.Category, vm => vm.MapFrom(m => m.Category))
                .ForMember(d => d.ImagesContent, vm => vm.MapFrom(m => m.ImagesContent))
                .ForMember(d => d.TextContent, vm => vm.MapFrom(m => m.TextContent))
                .ReverseMap();

            Mapper.CreateMap<ImagesContentDTO, ImagesContentViewModel>().ReverseMap();
            Mapper.CreateMap<TextContentDTO, TextContentViewModel>().ReverseMap();

            Mapper.CreateMap<ArticleDTO, Article>()
               .ForMember(d => d.Title, vm => vm.MapFrom(m => m.Title))
               .ForMember(d => d.Category, vm => vm.MapFrom(m => m.Category))
               .ForMember(d => d.ImagesContent, vm => vm.MapFrom(m => m.ImagesContent))
               .ForMember(d => d.TextContent, vm => vm.MapFrom(m => m.TextContent)).ReverseMap();

            Mapper.CreateMap<ImagesContentDTO, ImagesContent>().ReverseMap();
            Mapper.CreateMap<TextContentDTO, TextContent>().ReverseMap();

            Mapper.CreateMap<ContactsViewModel, ContactDTO>().ReverseMap();
            Mapper.CreateMap<ContactDTO, Contact>().ReverseMap();
            
            Mapper.CreateMap<MainPageViewModel, MainPhotoDTO>().ReverseMap();
            Mapper.CreateMap<MainPhotoDTO, MainPhoto>().ReverseMap();

            Mapper.CreateMap<NewsPageViewModel, NewsEventDTO>()
                .ForMember(dto=>dto.Date, vm=>vm.MapFrom(a=>DateTime.Parse(a.Date)))
                .ReverseMap();
            Mapper.CreateMap<NewsEventDTO, NewsEvent>().ReverseMap();

            Mapper.CreateMap<LinkViewModel, LinkDTO>().ReverseMap();
            Mapper.CreateMap<LinkDTO, Link>().ReverseMap();

           
            Mapper.CreateMap<GalleryLinkDTO, GalleryLink>().ReverseMap();

            Mapper.CreateMap<CreateNewsViewModel, NewsEventDTO>().ReverseMap();
            Mapper.CreateMap<NewsEventDTO, NewsEvent>().ReverseMap();



            Mapper.CreateMap<CreateArticleViewModel, ArticleDTO>()
                .ForMember(d => d.Title, vm => vm.MapFrom(m => m.Title))
                .ForMember(d => d.Category, vm => vm.MapFrom(m => m.SelectedCategory))
                .ForMember(d => d.ImagesContent, vm => vm.MapFrom(m => m.ImagesContent))
                .ForMember(d => d.TextContent, vm => vm.MapFrom(m => m.TextContent))
                .ReverseMap();

            Mapper.CreateMap<ArticleDTO, Article>().ReverseMap();
          
        }
    }
}
