using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class Municipio : EntityBase
    {
        public string Nombre { get; set; }
        public int ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
