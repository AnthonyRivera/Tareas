using Books.Api.Dtos.Books;
using Books.Api.Dtos.Rented;
using Books.Domain;
using Books.Domain.Models;

namespace Books.Api.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookBaseDto>()
                 .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                 .ReverseMap();
            CreateMap<Book, BookDto>()
               .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
               .ReverseMap();
            CreateMap<Book, CreateBookDto>()
                 .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                 .ReverseMap();
            CreateMap<Book, UpdateBookDto>()
                 .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                 .ReverseMap();

            CreateMap<Rented, RentedDto>().ReverseMap();

        }
    }
}
