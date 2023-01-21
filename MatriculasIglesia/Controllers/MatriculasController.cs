using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data.DataDBContext;
using Library.Data.Models;
using AutoMapper;
using MatriculasIglesia.Dtos.Matriculas;
using Library.Repository.Interfaces;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculasController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        private IUnitOfWork _uow;

        public MatriculasController(DataContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
        }

        // GET: api/Matriculas
        [HttpGet]
        public async Task<ActionResult> GetMatriculas()
        {
            var all = await _context.Matriculas
                .Include(a => a.Proyecto)
                .Include(a => a.Nino)
                .Include(a => a.Horario)
                .Include(a => a.Responsable)
                .ToListAsync();
            return Ok(_mapper.Map<List<MatriculaDto>>(all));
        }

        // GET: api/Matriculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // PUT: api/Matriculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(int id, CreateEditMatriculaDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            dto.IsMatriculado = await _uow.Proyectos.TieneCapacidad(dto.ProyectoID);
            var matricula = _mapper.Map<Matricula>(dto);
            _context.Entry(matricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Matriculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MatriculaDto>> PostMatricula(CreateEditMatriculaDto dto)
        {
            dto.IsMatriculado = await _uow.Proyectos.TieneCapacidad(dto.ProyectoID);
            dto.Fecha = DateTime.UtcNow;
            var matricula = _mapper.Map<Matricula>(dto);
            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            dto.Id = matricula.Id;
            return CreatedAtAction("GetMatricula", new { id = matricula.Id }, dto);
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
