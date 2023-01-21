using AutoMapper;
using Library.Data.Models;
using MatriculasIglesia.Dtos;
using MatriculasIglesia.Dtos.Iglesias;

namespace MatriculasIglesia.Mapper.Iglesias

{
    public class IglesiaToDto : Profile
    {
        public IglesiaToDto()
        {
            CreateMap<Iglesia, IglesiaDto>()
              .ForMember(dto => dto.Municipio, opt => opt.MapFrom(e => e.Municipio.Nombre))
              .ReverseMap();
        }
    }
}
