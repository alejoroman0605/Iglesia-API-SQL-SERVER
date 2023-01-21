using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data.DataDBContext;
using Library.Data.Models;
using MatriculasIglesia.Dtos.Personas;
using AutoMapper;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaMayorController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;

        public PersonaMayorController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PersonaMayor
        [HttpGet]
        public async Task<ActionResult> GetPersonaMayores()
        {
            var all = await _context.PersonaMayores
                .Include(p => p.Participaciones)
                    .ThenInclude(p => p.Actividad)
                .Include(p => p.Participaciones)
                    .ThenInclude(p => p.Nino)
                .Include(p=> p.GradoEscolar)
                .ToListAsync();
            return Ok(_mapper.Map<List<PersonaMayorDto>>(all));
        }

        // GET: api/PersonaMayor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaMayor>> GetPersonaMayor(int id)
        {
            var personaMayor = await _context.PersonaMayores.FindAsync(id);

            if (personaMayor == null)
            {
                return NotFound();
            }

            return personaMayor;
        }

        // PUT: api/PersonaMayor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaMayor(int id, CreateEditPersonaMayorDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var personaMayor = _mapper.Map<PersonaMayor>(dto);
            _context.Entry(personaMayor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaMayorExists(id))
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

        // POST: api/PersonaMayor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaMayor>> PostPersonaMayor(CreateEditPersonaMayorDto dto)
        {
            var personaMayor = _mapper.Map<PersonaMayor>(dto);
            _context.PersonaMayores.Add(personaMayor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonaMayor", new { id = personaMayor.Id }, personaMayor);
        }

        // DELETE: api/PersonaMayor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaMayor(int id)
        {
            var personaMayor = await _context.PersonaMayores.FindAsync(id);
            if (personaMayor == null)
            {
                return NotFound();
            }

            _context.PersonaMayores.Remove(personaMayor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaMayorExists(int id)
        {
            return _context.PersonaMayores.Any(e => e.Id == id);
        }
    }
}
