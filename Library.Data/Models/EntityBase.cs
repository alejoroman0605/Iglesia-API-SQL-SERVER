using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
