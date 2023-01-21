namespace MatriculasIglesia.Dtos
{
    public class PagedResultDto<Entity>
    {
        public int TotalCount { get; set; }
        public List<Entity> Items { get; set; }

        public PagedResultDto()
        {
            Items = new List<Entity>();
        }
    }
}
