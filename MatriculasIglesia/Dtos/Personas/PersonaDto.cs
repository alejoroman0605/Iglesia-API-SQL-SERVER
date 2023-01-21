namespace MatriculasIglesia.Dtos.Personas
{
    public class PersonaDto : EntityBaseDto
    {
        public string Nombre { get; set; }
        public string Ap1 { get; set; }
        public string Ap2 { get; set; }

        public string CI { get; set; }
        public string FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int GradoEscolarID { get; set; }
        public string GradoEscolar { get; set; }

        //public int? PadreID { get; set; }

        //public virtual Persona Padre { get; set; }
        //public virtual List<Persona> HijosDePadre { get; set; }

        //public int? MadreID { get; set; }
        //public virtual Persona Madre { get; set; }
        //public virtual List<Persona> HijosDeMadre { get; set; }

        public string SexoText { get; set; }
        public int Sexo { get; set; }

        public string FullName { get; set; }

        public int Edad { get; set; }

        public int? MadreID { get; set; }

        public int? PadreID { get; set; }
        

        public string? NombreMadre { get; set; }

        public string? NombrePadre { get; set; }

        public string? CentroMadre { get; set; }

        public string? CentroPadre { get; set; }

    }
}
