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
using MatriculasIglesia.Dtos.Participaciones;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacionController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public ParticipacionController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Participacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participacion>>> GetParticipaciones()
        {
            var all = await _context.Participaciones
                .Include(p => p.Actividad)
                .Include(p => p.PersonaMayor)
                .Include(p => p.Nino)
                .ToListAsync();
            return Ok(_mapper.Map<List<ParticipacionDto>>(all));
            
        }

        // GET: api/Participacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participacion>> GetParticipacion(int id)
        {
            var participacion = await _context.Participaciones.FindAsync(id);

            if (participacion == null)
            {
                return NotFound();
            }

            return participacion;
        }

        // PUT: api/Participacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipacion(int id, CreateEditParticipacionDto dto )
        {

            if (id != dto.Id)
            {
                return BadRequest();
            }
            var participacion = _mapper.Map<Participacion>(dto);
            _context.Entry(participacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipacionExists(id))
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

        // POST: api/Participacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participacion>> PostParticipacion(CreateEditParticipacionDto dto)
        {
            var participacion = _mapper.Map<Participacion>(dto);
            _context.Participaciones.Add(participacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipacion", new { id = participacion.Id }, participacion);
        }

        // DELETE: api/Participacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipacion(int id)
        {
            var participacion = await _context.Participaciones.FindAsync(id);
            if (participacion == null)
            {
                return NotFound();
            }

            _context.Participaciones.Remove(participacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipacionExists(int id)
        {
            return _context.Participaciones.Any(e => e.Id == id);
        }
    }
}
