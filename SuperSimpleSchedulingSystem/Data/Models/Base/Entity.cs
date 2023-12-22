using System.ComponentModel.DataAnnotations;

namespace SuperSimpleSchedulingSystem.Data.Models.Base
{
    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
