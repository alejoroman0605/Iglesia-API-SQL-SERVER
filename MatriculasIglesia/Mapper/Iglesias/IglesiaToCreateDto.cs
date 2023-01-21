using AutoMapper;
using Library.Data.Models;
using MatriculasIglesia.Dtos.Iglesias;

namespace MatriculasIglesia.Mapper.Iglesias

{
    public class IglesiaToCreateDto : Profile
    {
        public IglesiaToCreateDto()
        {
            CreateMap<Iglesia, CreateIglesiaDto>()
              .ReverseMap();
        }
    }
}
