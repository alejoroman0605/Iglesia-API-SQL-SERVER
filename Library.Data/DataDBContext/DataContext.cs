using Library.Data.Models;
using Library.Data.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.DataDBContext
{


    public class DataContext : DbContext
    {

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<GradoEscolar> GradoEscolar { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Iglesia> Iglesias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Nino> Ninos { get; set; }
        public DbSet<Participacion> Participaciones { get; set; }
        public DbSet<PersonaMayor> PersonaMayores { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<TipoActividad> TipoActividades { get; set; }

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=IglesiaDB2;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=DIGMARY\\SQLEXP;Database=IglesiaDB2;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            TipoActividadDBConfig.SetEntityBuilder(modelBuilder);
            ParticipacionDBConfig.SetEntityBuilder(modelBuilder);
            MatriculaDBConfig.SetEntityBuilder(modelBuilder);
            PersonaDBConfig.SetEntityBuilder(modelBuilder);
            IglesiaDBConfig.SetEntityBuilder(modelBuilder);
            ProyectoDBConfig.SetEntityBuilder(modelBuilder);
            
        }

    }
}
