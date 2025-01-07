using AutoMapper;
using Bookstore_Inventry.Models;

namespace Bookstore_Inventry.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
