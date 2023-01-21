using Library.Data;
using Library.Data.DataDBContext;
using Library.Data.Models;
using Library.Data.Repositories;
using Library.Repository.Interfaces.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository.Repositories.Repo
{
    public class ProyectoRepository : BaseRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> TieneCapacidad(int proyId)
        {
           var proy = await _context.Proyectos.Include(p => p.Matriculas).AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == proyId);
            if(proy == null)
                return false;
            return proy.Matriculas.Count(m => m.IsMatriculado) < proy.Capacidad;
        }

        
    }
}
