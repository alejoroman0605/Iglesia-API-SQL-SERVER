using MatriculasIglesia.Dtos.Personas;

namespace MatriculasIglesia.Dtos
{
    public class EstadisticaDto : EntityBaseDto
    {
        public int Inscripciones { get; set; }
        public int Matriculas { get; set; }
        public int ListaEspera {
            get
            {
                return Inscripciones - Matriculas;
            }
        }

        public int Proyectos { get; set; }

        public int Ninos { get; set; }

        public int Varones { get; set; }
        public int Hembras
        {
            get
            {
                return Ninos - Varones;
            }
        }

        public string PVarones
        {
            get
            {
                return ((Varones * 100.0) / Ninos).ToString("0.00");
            }
        }
        public string PHembras
        {
            get
            {
                return ((Hembras * 100.0) / Ninos).ToString("0.00");
            }
        }

        public int Actividades { get; set; }

        /// <summary>
        /// Top 5, ninos q mas participaciones tienen en proyecto ordenados desc by participacion
        /// </summary>
        public ICollection<NinoDto> NinoProyectos { get; set; }

        public EstadisticaDto()
        {
            NinoProyectos = new HashSet<NinoDto>();
        }
    }
}
