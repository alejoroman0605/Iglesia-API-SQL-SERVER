using Library.Data;
using Library.Data.DataDBContext;
using Library.Data.Models;
using Library.Data.Repositories;
using Library.Repository.Interfaces.IRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Repository.Repositories.Repo
{
    public class IglesiaRepository : BaseRepository<Iglesia>, IIglesiaRepository
    {
        public IglesiaRepository(DataContext context) : base(context)
        {
        }

        //public override IQueryable<Recess> GetQuery(params Expression<Func<Recess, object>>[] includeProperties)
        //{
        //    IQueryable<Recess> query = _context.Set<Recess>();
        //    return query.Include(r => r.CalendarRecesses).ThenInclude(cr => cr.Calendar);
        //}

        //public async Task<bool> AnyWithNameAsync(string name, /*int calendarID,*/ int? id = null)
        //{
        //    return await _context.Recesses.AnyAsync(e => 
        //    e.Name.ToLower() == name.ToLower() && /*e.CalendarID == calendarID &&*/ e.Id != id);
        //}
    }
}
