using SuperSimpleSchedulingSystem.Data.Models.Base;
using SuperSimpleSchedulingSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SuperSimpleSchedulingSystem.Data.Models
{
    public class Class : Entity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Teacher { get; set; }

        [Required]
        public ScheduleEnum Schedule { get; set; }


        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
