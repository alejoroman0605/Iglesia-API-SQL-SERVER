using AutoMapper;
using Library.Data.DataDBContext;
using Library.Data.Models;
using MatriculasIglesia.Dtos;
using MatriculasIglesia.Dtos.Personas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly DataContext _context;
        private IMapper _mapper;
        public DashBoardController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<DashBoardController>
        [HttpGet("[action]")]
        public async Task<ActionResult> GetEstadisticas()
        {
            var matriculas = await _context.Matriculas.ToListAsync();
            var proyectos = await _context.Proyectos.ToListAsync();
            var ninos = await _context.Ninos.Include(n => n.Matriculas).Include(n=> n.GradoEscolar).ToListAsync();
            foreach (var n in ninos)
            {
                var mats = new List<Matricula>();
                foreach (var m in n.Matriculas)
                {
                    if (m.IsMatriculado)
                        mats.Add(m);
                }
                n.Matriculas = mats;
            }
            var actividades = await _context.Actividades.ToListAsync();
            EstadisticaDto est = new EstadisticaDto();
            est.Inscripciones = matriculas.Count;
            est.Matriculas = matriculas.Count(m => m.IsMatriculado);
            est.Proyectos = proyectos.Count;
            est.Ninos = ninos.Count;
            est.Varones = ninos.Count(n => n.Sexo == Library.Data.Enums.Sexo.Masculino);
            est.Actividades = actividades.Count;

            List<Nino> topFive = ninos.OrderByDescending(n => n.Matriculas.Count).ThenBy(n => n.FechaNac).Take(5).ToList();
            est.NinoProyectos = _mapper.Map<List<NinoDto>>(topFive);
            return Ok(est);
        }

        
    }
}
