using SuperSimpleSchedulingSystem.Logic.Models.Validation;

namespace SuperSimpleSchedulingSystem.Logic.Models
{
    public class StudentDto : BaseValidatable, IValidatable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }

        public virtual UserDto User { get; set; }
        public virtual ICollection<ClassDto> Classes { get; set; }

        public override bool IsValid()
        {
            if (String.IsNullOrEmpty(FirstName))
            {
                AddError(new ValidationError
                {
                    Field = "FirstName",
                    Message = "The FirstName field is required."
                });
            }
            if (String.IsNullOrEmpty(LastName))
            {
                AddError(new ValidationError
                {
                    Field = "LastName",
                    Message = "The LastName field is required."
                });
            }
            if (UserId.Equals(Guid.Empty))
            {
                AddError(new ValidationError
                {
                    Field = "UserId",
                    Message = "The UserId field is required."
                });
            }
            return !Errors.Any();
        }
    }
}
