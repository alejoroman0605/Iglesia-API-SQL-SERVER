using Library.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public abstract class Persona : EntityBase
    {
        public string Nombre{ get; set; }
        public string Ap1 { get; set; }
        public string Ap2 { get; set; }

        public string CI { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int GradoEscolarID { get; set; }
        public virtual GradoEscolar GradoEscolar { get; set; }

        public int? PadreID { get; set; }

        public virtual Persona? Padre { get; set; }
        public virtual List<Persona> HijosDePadre { get; set; }

        public int? MadreID { get; set; }
        public virtual Persona? Madre { get; set; }
        public virtual List<Persona> HijosDeMadre { get; set; }

        public Sexo Sexo { get; set; }

        public string FullName {
            get {
                return Nombre + " " + Ap1 + " " + Ap2;
            }
        }

        public Persona()
        {  

        }
    }
}
