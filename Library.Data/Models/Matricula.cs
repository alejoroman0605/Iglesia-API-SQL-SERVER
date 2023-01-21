using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    /// <summary>
    /// Join table
    /// </summary>
    public class Matricula : EntityBase
    {
        public int ProyectoID { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public int NinoID { get; set; }
        public virtual Nino Nino { get; set; }

        public int ResponsableID { get; set; }
        public virtual PersonaMayor Responsable { get; set; }

        public DateTime Fecha { get; set; }

        public int HorarioID { get; set; }
        public virtual Horario Horario { get; set; }

        public bool IsMatriculado { get; set; }

    }
}