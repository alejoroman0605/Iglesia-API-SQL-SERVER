using Library.Data.DataDBContext;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    public class MunicipioController : Controller
    {
        private readonly DataContext _context;
        public MunicipioController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet("[action]")]
        public async Task<IEnumerable<Municipio>> GetAll()
        {
            return await _context.Municipios.Include(m=> m.Provincia).ToListAsync();
        }
    }
}
