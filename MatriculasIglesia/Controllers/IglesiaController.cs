using AutoMapper;
using Library.Data.Models;
using Library.Service.Interfaces.IServ;
using MatriculasIglesia.Controllers.EndPointBase;
using MatriculasIglesia.Dtos;
using MatriculasIglesia.Dtos.Iglesias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatriculasIglesia.Controllers
{

    public class IglesiaController : EndpointControllerBase<Iglesia, IglesiaDto, CreateIglesiaDto, EditIglesiaDto, IglesiaDto, PagedListInputDto>
    {
        public IglesiaController(IMapper mapper, IIglesiaService baseService) : base(mapper, baseService)
        {

        }
    }
}
