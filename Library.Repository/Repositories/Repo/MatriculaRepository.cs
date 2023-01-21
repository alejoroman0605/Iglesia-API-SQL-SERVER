using Library.Data;
using Library.Data.DataDBContext;
using Library.Data.Models;
using Library.Data.Repositories;
using Library.Repository.Interfaces.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository.Repositories.Repo
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> AnyMatriculadoAsync(int ProyectoID, int NinoID, int Id)
        {
            return await _context.Matriculas.AnyAsync(m => m.ProyectoID == ProyectoID && m.NinoID == NinoID
                && m.Id != Id);
        }


    }
}
