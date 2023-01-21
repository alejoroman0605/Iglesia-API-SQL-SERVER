using Library.Data.DataDBContext;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    public class ProvinciaController : Controller
    {
        private readonly DataContext _context;
        public ProvinciaController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet("[action]")]
        public async Task<IEnumerable<Provincia>> GetAll()
        {
            return await _context.Provincias.ToListAsync();
        }
    }
}
