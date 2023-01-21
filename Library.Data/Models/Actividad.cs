namespace Library.Data.Models
{
    public class Actividad : EntityBase
    {
        public string Nombre { get; set; }

        public int TipoActividadID { get; set; }
        public virtual  TipoActividad TipoActividad { get; set; }

        public virtual ICollection<Participacion> Participaciones { get; set; }

        public Actividad()
        {
            Participaciones = new HashSet<Participacion>();
        }
    }
}