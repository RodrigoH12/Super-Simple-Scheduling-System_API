using SuperSimpleSchedulingSystem.Logic.Models.Validation;

namespace SuperSimpleSchedulingSystem.Logic.Models
{
    public class UserDto : BaseValidatable, IValidatable
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual StudentDto? Student { get; set; }

        public override bool IsValid()
        {
            if (String.IsNullOrEmpty(UserName))
            {
                AddError(new ValidationError
                {
                    Field = "UserName",
                    Message = "The UserName field is required."
                });
            }
            if (String.IsNullOrEmpty(Password))
            {
                AddError(new ValidationError
                {
                    Field = "Password",
                    Message = "The Password field is required."
                });
            }
            return !Errors.Any();
        }
    }
}
