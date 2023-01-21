using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class PersonaMayor : Persona
    {
        public string CentroTrabajo { get; set; }

        public virtual ICollection<Participacion> Participaciones { get; set; }

        public virtual ICollection<Proyecto>? AdminProyectos { get; set; }

        public virtual ICollection<Proyecto>? CoordinadorProyectos { get; set; }
        public virtual ICollection<Matricula>? Matriculas { get; set; }

        public PersonaMayor()
        {
            Participaciones = new HashSet<Participacion>();
            AdminProyectos = new HashSet<Proyecto>();
            CoordinadorProyectos= new HashSet<Proyecto>();
            Matriculas = new HashSet<Matricula>();
        }
    }
}
