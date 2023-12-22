using SuperSimpleSchedulingSystem.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SuperSimpleSchedulingSystem.Data.Models
{
    public class Student : Entity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public Guid UserId { get; set; }


        public virtual User User { get; set; }
        public virtual IEnumerable<Class>? Classes { get; set; }
    }
}
