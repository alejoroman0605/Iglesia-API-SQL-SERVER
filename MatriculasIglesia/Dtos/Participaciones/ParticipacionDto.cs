

using MatriculasIglesia.Dtos;

namespace MatriculasIglesia.Dtos.Participaciones
{
    public class ParticipacionDto : EntityBaseDto
    {
        public string Fecha { get; set; }

        public string Observacion { get; set; }

        public int ActividadID { get; set; }
        public string Actividad { get; set; }

        public int NinoID { get; set; }
        public string Nino { get; set; }

        public int PersonaMayorID { get; set; }
        public string PersonaMayor { get; set; }
    }
}
