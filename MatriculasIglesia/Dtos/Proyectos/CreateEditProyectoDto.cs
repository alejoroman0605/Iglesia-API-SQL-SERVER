namespace MatriculasIglesia.Dtos.Proyectos
{
    public class CreateEditProyectoDto : EntityBaseDto
    {
        public string Nombre { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }

        public int IglesiaID { get; set; }
       

        public int CoordinadorID { get; set; }

        public int AdministradorID { get; set; }

        //public virtual ICollection<Matricula> Matriculas { get; set; }

        public int? Capacidad { get; set; }

    }
}
