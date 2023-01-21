

using MatriculasIglesia.Dtos;

namespace MatriculasIglesia.Dtos.Iglesias
{
    public class IglesiaDto : EntityBaseDto
    {
        public string Nombre { get; set; }
        public int MunicipioID { get; set; }
        public string Municipio { get; set; }
    }
}
