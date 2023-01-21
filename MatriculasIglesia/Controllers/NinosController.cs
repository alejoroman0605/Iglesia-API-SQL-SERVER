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
using MatriculasIglesia.Dtos.Personas;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinosController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public NinosController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Ninoes
        [HttpGet]
        public async Task<ActionResult> GetNinos()
        {
            var all = await _context.Ninos
                .Include(p => p.Madre)
                .Include(p => p.Padre)
                .Include(p => p.GradoEscolar)
                .Include(p => p.Participaciones)
                    .ThenInclude(p => p.Actividad)
                .Include(p => p.Participaciones)
                    .ThenInclude(p => p.PersonaMayor)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Horario)
                .Include(p => p.Matriculas)
                    .ThenInclude(p => p.Responsable)
                .Include(p => p.Matriculas)
                    .ThenInclude(p => p.Proyecto)
                
                .ToListAsync();
            return Ok(_mapper.Map<List<NinoDto>>(all));
        }

        // GET: api/Ninoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nino>> GetNino(int id)
        {
            var nino = await _context.Ninos.FindAsync(id);

            if (nino == null)
            {
                return NotFound();
            }

            return nino;
        }

        // PUT: api/Ninoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNino(int id, CreateEditNinoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var nino = _mapper.Map<Nino>(dto);
            _context.Entry(nino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NinoExists(id))
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

        // POST: api/Ninoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nino>> PostNino(CreateEditNinoDto dto)
        {
            var nino = _mapper.Map<Nino>(dto);
            _context.Ninos.Add(nino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNino", new { id = nino.Id }, nino);
        }

        // DELETE: api/Ninoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNino(int id)
        {
            var nino = await _context.Ninos.FindAsync(id);
            if (nino == null)
            {
                return NotFound();
            }

            _context.Ninos.Remove(nino);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NinoExists(int id)
        {
            return _context.Ninos.Any(e => e.Id == id);
        }
    }
}
