using Books.Api.Dtos.Books;
using Books.Domain;
using Books.Domain.Models;

namespace Books.Api.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteBaseDto>()
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                 .ReverseMap();
            CreateMap<Paciente, PacienteDto>()
               .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
               .ReverseMap();
            CreateMap<Paciente, PacienteBookDto>()
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                 .ReverseMap();
            CreateMap<Paciente, UpdateBookDto>()
                 .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                 .ReverseMap();


        }
    }
}
