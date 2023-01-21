using Library.Data.Enums;

namespace MatriculasIglesia.Dtos.Personas
{
    public class CreateEditPersonaDto : EntityBaseDto
    {
        public string Nombre { get; set; }
        public string Ap1 { get; set; }
        public string Ap2 { get; set; }

        public string CI { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int GradoEscolarID { get; set; }

        public int? PadreID { get; set; }

        public int? MadreID { get; set; }


        public Sexo Sexo { get; set; }

        
    }
}
