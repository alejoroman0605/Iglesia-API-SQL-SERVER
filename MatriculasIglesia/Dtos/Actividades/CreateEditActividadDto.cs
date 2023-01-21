namespace MatriculasIglesia.Dtos.Actividades
{
    public class CreateEditActividadDto : EntityBaseDto
    {
        public string Nombre { get; set; }

        public int TipoActividadID { get; set; }
        
    }
}
