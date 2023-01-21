namespace Library.Data.Models
{
    public class Horario : EntityBase
    {
        public string Inicio { get; set; }
        public string Fin { get; set; }

        public string Rango
        {
            get
            {
                return Inicio + " a " + Fin;

            }
        }
    }
}