using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Iglesia : EntityBase
    {
        public string Nombre { get; set; }
        public int MunicipioID { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
