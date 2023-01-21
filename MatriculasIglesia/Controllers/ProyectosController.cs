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
using MatriculasIglesia.Dtos.Proyectos;
using DinkToPdf;
using DinkToPdf.Contracts;
using Library.Service.Common;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        private readonly IConverter _converter;

        public ProyectosController(DataContext context, IMapper mapper, IConverter converter)
        {
            _context = context;
            _mapper = mapper;
            _converter = converter;
        }

        // GET: api/Proyectoes
        [HttpGet]
        public async Task<ActionResult> GetProyectos()
        {
            var all = await _context.Proyectos
                .Include(p => p.Iglesia)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Responsable)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Nino)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Horario)
                .ToListAsync();
            return Ok( _mapper.Map<List<ProyectoDto>>(all));
        }

        // GET: api/Proyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);

            if (proyecto == null)
            {
                return NotFound();
            }

            return proyecto;
        }

        // PUT: api/Proyectoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyecto(int id, CreateEditProyectoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var proyecto = _mapper.Map<Proyecto>(dto);
            _context.Entry(proyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoExists(id))
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

        // POST: api/Proyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proyecto>> PostProyecto(CreateEditProyectoDto dto)
        {
            var proyecto = _mapper.Map<Proyecto>(dto);
            _context.Proyectos.Add(proyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyecto", new { id = proyecto.Id }, proyecto);
        }

        // DELETE: api/Proyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(proyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProyectoExists(int id)
        {
            return _context.Proyectos.Any(e => e.Id == id);
        }

        [HttpGet("[action]/{proyID}")]
        public async Task<IActionResult> GeneratePDF(int proyID)
        {
            //seria mejor hacer la consulta en el repo
            var proyecto = await _context.Proyectos
                .Include(p=> p.Administrador)
                .Include(p => p.Coordinador)
                .Include(p => p.Iglesia)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Responsable)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Nino)
                .Include(p => p.Matriculas)
                    .ThenInclude(m => m.Horario)
                .FirstOrDefaultAsync(p => p.Id == proyID);
            if (proyecto == null)
                return NotFound();
            var proyectoDto = _mapper.Map<ProyectoDto>(proyecto);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF - Reporte"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(proyectoDto),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Iglesia Reporte" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file,
            "application/octet-stream", "Reporte.pdf");
        }
    }
}
