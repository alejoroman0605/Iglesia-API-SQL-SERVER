

using MatriculasIglesia.Dtos;
using MatriculasIglesia.Dtos.Matriculas;

namespace MatriculasIglesia.Dtos.Proyectos
{
    public class ProyectoDto : EntityBaseDto
    {
        public string Nombre { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }

        public int IglesiaID { get; set; }
        public string Iglesia { get; set; }

        public int CoordinadorID { get; set; }

        public string Coordinador { get; set; }

        public int AdministradorID { get; set; }

        public string Administrador { get; set; }

        public ICollection<MatriculaDto> Matriculas { get; set; }

        public int Capacidad { get; set; }
    }
}
