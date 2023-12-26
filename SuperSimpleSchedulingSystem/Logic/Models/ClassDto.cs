using SuperSimpleSchedulingSystem.Data.Models.Enums;
using SuperSimpleSchedulingSystem.Logic.Models.Validation;

namespace SuperSimpleSchedulingSystem.Logic.Models
{
    public class ClassDto : BaseValidatable, IValidatable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
        public ScheduleEnum Schedule { get; set; }
    
        public virtual ICollection<StudentDto> Students { get; set; }

        public override bool IsValid()
        {
            if (String.IsNullOrEmpty(Title))
            {
                AddError(new ValidationError
                {
                    Field = "Title",
                    Message = "The Title field is required."
                });
            }
            if (String.IsNullOrEmpty(Description))
            {
                AddError(new ValidationError
                {
                    Field = "Description",
                    Message = "The Description field is required."
                });
            }
            if (String.IsNullOrEmpty(Teacher))
            {
                AddError(new ValidationError
                {
                    Field = "Teacher",
                    Message = "The Teacher field is required."
                });
            }
            if (!Enum.IsDefined(typeof(ScheduleEnum), Schedule))
            {
                AddError(new ValidationError
                {
                    Field = "Schedule",
                    Message = "The Schedule field is required and needs to be " +
                              "A = 0, B = 1, C = 2 or D = 3"
                });
            }
            return !Errors.Any();
        }
    }
}
