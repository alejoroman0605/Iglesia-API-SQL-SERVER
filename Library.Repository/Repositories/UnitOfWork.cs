using Library.Data.DataDBContext;
using Library.Repository.Interfaces;

using Library.Repository.Interfaces.IRepo;
using Library.Repository.Repositories.Repo;

namespace Library.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;


        public IIglesiaRepository Iglesias { get; }
        public IMatriculaRepository Matriculas { get; }

        public IProyectoRepository Proyectos { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;

            Iglesias = new IglesiaRepository(context);
            Matriculas = new MatriculaRepository(context);
            Proyectos = new ProyectoRepository(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose() => _context.Dispose();
    }
}
