using MatriculasIglesia.Dtos.Participaciones;

namespace MatriculasIglesia.Dtos.Personas
{
    public class PersonaMayorDto : PersonaDto
    {
        public string CentroTrabajo { get; set; }

        public virtual ICollection<ParticipacionDto> Participaciones { get; set; }
    }
}
