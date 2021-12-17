using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ViewModel;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (GenreEnum)src.GenreId)).ToString();
            CreateMap<Book, CreateBookModel>().ReverseMap();
            CreateMap<Book, UpdateBookModel>().ReverseMap();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest =>dest.Genre,opt=>opt.MapFrom(src => (GenreEnum)src.GenreId)).ToString();

        }
    }
}
