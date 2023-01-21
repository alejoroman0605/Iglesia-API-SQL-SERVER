using AutoMapper;
using Library.Data.Models;
using MatriculasIglesia.Dtos;
using MatriculasIglesia.Dtos.Iglesias;

namespace MatriculasIglesia.Mapper.Iglesias

{
    public class IglesiaToEditDto : Profile
    {
        public IglesiaToEditDto()
        {
            CreateMap<Iglesia, EditIglesiaDto>()
              .ReverseMap();
        }
    }
}
