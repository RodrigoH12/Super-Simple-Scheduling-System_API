namespace SuperSimpleSchedulingSystem.Logic.Models.Validation
{
    public abstract class BaseValidatable : IValidatable
    {
        protected IEnumerable<ValidationError> Errors;

        protected BaseValidatable()
        {
            Errors = new List<ValidationError>();
        }

        public abstract bool IsValid();

        protected void AddError(ValidationError error)
        {
            ((List<ValidationError>)Errors).Add(error);
        }

        public IEnumerable<ValidationError> GetErrors()
        {
            return Errors;
        }
    }
}
