using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Proyecto : EntityBase
    {
        public string Nombre{ get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }

        public int IglesiaID { get; set; }
        public virtual Iglesia Iglesia { get; set; }

        public int CoordinadorID { get; set; }
        
        public virtual PersonaMayor Coordinador { get; set; }

        public int AdministradorID { get; set; }
 
        public virtual PersonaMayor Administrador { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }

        public int Capacidad { get; set; }

        public Proyecto()
        {
            Matriculas = new HashSet<Matricula>();
        }
    }
}
