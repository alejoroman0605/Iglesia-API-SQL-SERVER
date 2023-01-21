using Library.Repository.Interfaces.IRepo;

namespace Library.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        public IIglesiaRepository Iglesias { get; }
        public IMatriculaRepository Matriculas { get; }
        public IProyectoRepository Proyectos { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
