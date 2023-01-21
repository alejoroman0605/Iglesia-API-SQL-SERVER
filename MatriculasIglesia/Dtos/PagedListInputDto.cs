namespace MatriculasIglesia.Dtos
{
    public class PagedListInputDto 
    {
        /// <summary>
        /// Number of records to skip in the list.
        /// </summary>
        public int SkipCount { get; set; }
        /// <summary>
        /// Maximum number of records to display in the list.
        /// If not specified, all will be returned.
        /// </summary>
        public int? MaxResultCount { get; set; }
    }
}
