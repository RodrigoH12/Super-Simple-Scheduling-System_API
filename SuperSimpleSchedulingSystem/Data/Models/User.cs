using SuperSimpleSchedulingSystem.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SuperSimpleSchedulingSystem.Data.Models
{
    public class User : Entity
    {
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }


        public virtual Student? Student { get; set; }
    }
}
