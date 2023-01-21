using Library.Data.Enums;

namespace MatriculasIglesia.Dtos.Personas
{
    public class CreateEditPersonaMayorDto : CreateEditPersonaDto
    {
        public string CentroTrabajo { get; set; }
    }
}
