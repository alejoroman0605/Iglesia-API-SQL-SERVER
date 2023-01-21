using Library.Data.DataDBContext;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatriculasIglesia.Controllers
{
    [Route("api/[controller]")]
    public class GradoEscolarController : Controller
    {
        private readonly DataContext _context;
        public GradoEscolarController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet("[action]")]
        public async Task<IEnumerable<GradoEscolar>> GetAll()
        {
            return await _context.GradoEscolar.ToListAsync();
        }
    }
}
