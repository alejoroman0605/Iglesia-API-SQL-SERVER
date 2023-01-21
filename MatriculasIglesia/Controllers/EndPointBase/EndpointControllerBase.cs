using AutoMapper;

using Library.Data;
using Library.Data.Models;
using Library.Service.Common;
using Library.Service.Enum;
using Library.Service.Interfaces;
using MatriculasIglesia.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace MatriculasIglesia.Controllers.EndPointBase
{
    //[AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointControllerBase<TEntity, TEntityDto, CreateDto, EditDto, ItemMainListDto, PagedListInputDto> : ControllerBase
        where TEntity : EntityBase 
        where TEntityDto : EntityBaseDto 
        where EditDto : EntityBaseDto 
        where PagedListInputDto : Dtos.PagedListInputDto
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseService<TEntity> _baseService;

        public EndpointControllerBase(IMapper mapper, IBaseService<TEntity> baseService)
        {
            this._baseService = baseService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<TEntityDto>>> GetAll()
        {
            try
            {
                IEnumerable<TEntityDto> result = _mapper.Map<IEnumerable<TEntityDto>>(await _baseService.GetAllAsync());
                return ReturnBase<IEnumerable<TEntityDto>>.Result(result, System.Net.HttpStatusCode.OK, new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TEntityDto>>.Result(null, System.Net.HttpStatusCode.BadRequest,
                     new ModelEnum
                     {
                         Descricao = "Falha ao Atualizar a Página.",
                         Nome = Request.Method + ": " + Request.Path.Value
                     }, ex);
            }
        }

        /// <summary>
        /// Create a new entity 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<TEntityDto>> Create(CreateDto createDto)
        {
            try
            {
                TEntity entity = _mapper.Map<TEntity>(createDto);
                EntityEntry<TEntity> result = await _baseService.AddAsync(entity);
                await _baseService.SaveChangesAsync();

                TEntityDto entityDto = _mapper.Map<TEntityDto>(result.Entity);
                return ReturnBase<TEntityDto>.Result(entityDto, System.Net.HttpStatusCode.OK,
                    new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<TEntityDto>.Result(null, System.Net.HttpStatusCode.BadRequest,
                    new ModelEnum
                    { Descricao = "Falha ao Incluir o Registro.", Nome = Request.Method + ": " + Request.Path.Value },
                    ex);
            }
        }

        /// <summary>
        /// Update an entity by id
        /// </summary>
        /// <returns></returns>
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<EditDto>> Update(int id, EditDto editDto)
        {
            try
            {
                if (id != editDto.Id)
                {
                    throw new Exception("Erro na atualização");
                }
                TEntity entity = _mapper.Map<TEntity>(editDto);
                EntityEntry<TEntity> result = _baseService.Update(entity);
                await _baseService.SaveChangesAsync();

                TEntityDto entityDto = _mapper.Map<TEntityDto>(result.Entity);

                return ReturnBase<EditDto>.Result(editDto, System.Net.HttpStatusCode.OK,
                      new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<EditDto>.Result(editDto, System.Net.HttpStatusCode.BadRequest,
                    new ModelEnum
                    {
                        Descricao = "Falha ao Atualizar o Registro.",
                        Nome = Request.Method + ": " + Request.Path.Value
                    }, ex);
            }
        }

        /// <summary>
        /// Get paginated the main list of entities
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<PagedResultDto<ItemMainListDto>>> GetPagedMainListAsync([FromQuery] PagedListInputDto inputDto)
        {
            try
            {
                (IEnumerable<TEntity> result, int totalCount) = await ApplyFilters(inputDto);

                PagedResultDto<ItemMainListDto> pagedResultDto = new PagedResultDto<ItemMainListDto>
                {
                    Items = _mapper.Map<List<ItemMainListDto>>(result),
                    TotalCount = totalCount
                };
                return ReturnBase<PagedResultDto<ItemMainListDto>>.Result(pagedResultDto, System.Net.HttpStatusCode.OK, new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<PagedResultDto<ItemMainListDto>>.Result(null, System.Net.HttpStatusCode.BadRequest,
                     new ModelEnum
                     {
                         Descricao = "Falha ao Atualizar a Página.",
                         Nome = Request.Method + ": " + Request.Path.Value
                     }, ex);
            }
            
        }


        /// <summary>
        /// Get an entity by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<TEntityDto>> FindById(int id)
        {
            try
            {
                TEntity? result = await _baseService.FindByIdAsync(id);

                TEntityDto entityDto = _mapper.Map<TEntityDto>(result);

                if (entityDto == null)
                    return ReturnBase<TEntityDto>.Result(null, System.Net.HttpStatusCode.NotFound,
                        new ModelEnum
                        {
                            Descricao = $"O Registro Id:{id} não foi encontrado.",
                            Nome = Request.Method + ": " + Request.Path.Value
                        });

                return ReturnBase<TEntityDto>.Result(entityDto, System.Net.HttpStatusCode.OK,
                    new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<TEntityDto>.Result(null, System.Net.HttpStatusCode.BadRequest,
                    new ModelEnum
                    {
                        Descricao = "Falha ao Procurar o Registro.",
                        Nome = Request.Method + ": " + Request.Path.Value
                    }, ex);
            }
        }

        /// <summary>
        /// Delete an entity by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<TEntityDto>> Delete(int id)
        {
            try
            {
                EntityEntry<TEntity> result = await _baseService.Delete(id);
                if (result == null)
                    return ReturnBase<TEntityDto>.Result(null, System.Net.HttpStatusCode.NotFound,
                        new ModelEnum
                        {
                            Descricao = $"O Registro Id:{id} não foi encontrado.",
                            Nome = Request.Method + ": " + Request.Path.Value
                        });
                await _baseService.SaveChangesAsync();

                TEntityDto entityDto = _mapper.Map<TEntityDto>(result.Entity);

                return ReturnBase<TEntityDto>.Result(entityDto, System.Net.HttpStatusCode.OK,
                    new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<TEntityDto>.Result(null, System.Net.HttpStatusCode.BadRequest,
                    new ModelEnum
                    { Descricao = "Falha ao Excluir o Registro.", Nome = Request.Method + ": " + Request.Path.Value },
                    ex);
            }
        }

        /// <summary>
        /// Get a dropdown items list 
        /// </summary>
        /// <param name="valueProperty">Property name for value to item</param>
        /// <param name="displayTextProperty">Property name for display to item</param>
        /// <param name="selectedValue">Selected value</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public virtual async Task<ActionResult<SelectList>> GetAllDropdownItems([FromQuery] string valueField, [FromQuery] string displayTextField, [FromQuery] object selectedValue)
        {
            try
            {
                IEnumerable<TEntity> entities = await _baseService.GetAllAsync();

                SelectList selectList = new SelectList(entities, valueField, displayTextField, selectedValue);
                return ReturnBase<SelectList>.Result(selectList, System.Net.HttpStatusCode.OK, new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<SelectList>.Result(null, System.Net.HttpStatusCode.BadRequest,
                     new ModelEnum
                     {
                         Descricao = "Falha ao Atualizar a Página.",
                         Nome = Request.Method + ": " + Request.Path.Value
                     }, ex);
            }
        }


        /// <summary>
        /// Get entity for update
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetForEdit/{id}")]
        public virtual async Task<ActionResult<EditDto>> GetForEdit(int id)
        {
            try
            {
                TEntity? result = await _baseService.FindByIdAsync(id);

                if (result == null)
                    return ReturnBase<EditDto>.Result(null, System.Net.HttpStatusCode.NotFound,
                        new ModelEnum
                        {
                            Descricao = $"O Registro Id:{id} não foi encontrado.",
                            Nome = Request.Method + ": " + Request.Path.Value
                        });

                EditDto entityDto = _mapper.Map<EditDto>(result);
                return ReturnBase<EditDto>.Result(entityDto, System.Net.HttpStatusCode.OK, new ModelEnum { Descricao = "Sucesso", Nome = Request.Method + ": " + Request.Path.Value });
            }
            catch (Exception ex)
            {
                return ReturnBase<EditDto>.Result(null, System.Net.HttpStatusCode.BadRequest,
                     new ModelEnum
                     {
                         Descricao = "Falha ao Atualizar a Página.",
                         Nome = Request.Method + ": " + Request.Path.Value
                     }, ex);
            }
        }

        protected virtual Task<(IEnumerable<TEntity>, int)> ApplyFilters(PagedListInputDto inputDto)
        {
            return _baseService.GetPagedListAsync(inputDto.SkipCount, inputDto.MaxResultCount);
        }

    }
}
