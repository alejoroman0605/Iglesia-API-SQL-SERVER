namespace MatriculasIglesia.Dtos.Matriculas
{
    public class CreateEditMatriculaDto : EntityBaseDto
    {
        public int ProyectoID { get; set; }

        public int NinoID { get; set; }

        public int ResponsableID { get; set; }

        public DateTime Fecha { get; set; }

        public int HorarioID { get; set; }

        public bool IsMatriculado { get; set; }

    }
}
