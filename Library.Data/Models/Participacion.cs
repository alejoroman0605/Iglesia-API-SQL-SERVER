namespace Library.Data.Models
{
    public class Participacion : EntityBase
    {
        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }

        public int ActividadID { get; set; }
        public virtual Actividad Actividad { get; set; }

        public int NinoID { get; set; }
        public virtual Nino Nino { get; set; }

        public int PersonaMayorID { get; set; }
        public virtual PersonaMayor PersonaMayor { get; set; }
    }
}