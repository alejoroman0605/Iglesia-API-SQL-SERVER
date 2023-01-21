using MatriculasIglesia.Dtos.Matriculas;
using MatriculasIglesia.Dtos.Participaciones;

namespace MatriculasIglesia.Dtos.Personas
{
    public class NinoDto : PersonaDto
    {
        public bool PIS { get; set; }
        public double Hora { get; set; }

        public bool TienePermisoIrse { get; set; }

        public virtual ICollection<MatriculaDto> Matriculas { get; set; }
        public virtual ICollection<ParticipacionDto> Participaciones { get; set; }

        
    }
}
