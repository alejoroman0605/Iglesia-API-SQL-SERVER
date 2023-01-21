namespace MatriculasIglesia.Dtos.Participaciones
{
    public class CreateEditParticipacionDto : EntityBaseDto
    {
        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }

        public int ActividadID { get; set; }

        public int NinoID { get; set; }

        public int PersonaMayorID { get; set; }

    }
}
