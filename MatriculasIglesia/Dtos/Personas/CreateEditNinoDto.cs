using Library.Data.Enums;

namespace MatriculasIglesia.Dtos.Personas
{
    public class CreateEditNinoDto : CreateEditPersonaDto
    {
        public bool PIS { get; set; }
        public double Hora { get; set; }

        public bool TienePermisoIrse { get; set; }
    }
}
