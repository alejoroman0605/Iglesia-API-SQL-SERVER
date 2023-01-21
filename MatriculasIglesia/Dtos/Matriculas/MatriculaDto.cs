

using MatriculasIglesia.Dtos;

namespace MatriculasIglesia.Dtos.Matriculas
{
    public class MatriculaDto : EntityBaseDto
    {
        public int ProyectoID { get; set; }
        public string Proyecto { get; set; }

        public int NinoID { get; set; }
        public string Nino { get; set; }

        public int ResponsableID { get; set; }
        public string Responsable { get; set; }

        public string Fecha { get; set; }

        public int HorarioID { get; set; }
        public string Horario { get; set; }

        public bool IsMatriculado { get; set; }
    }
}
