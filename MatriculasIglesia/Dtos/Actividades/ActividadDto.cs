

using MatriculasIglesia.Dtos;

namespace MatriculasIglesia.Dtos.Actividades
{
    public class ActividadDto : EntityBaseDto
    {
        public string Nombre { get; set; }

        public int TipoActividadID { get; set; }
        public string TipoActividad { get; set; }
    }
}
