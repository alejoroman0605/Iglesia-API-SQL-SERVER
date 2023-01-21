using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Nino : Persona
    {
        public bool  PIS { get; set; }
        public double Hora { get; set; }

        public bool TienePermisoIrse { get; set; }


        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Participacion> Participaciones { get; set; }

        public Nino()
        {
            Matriculas = new HashSet<Matricula>();
            Participaciones = new HashSet<Participacion>();
        }
    }
}
