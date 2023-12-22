namespace SuperSimpleSchedulingSystem.Logic.Models.Validation
{
    public interface IValidatable
    {
        bool IsValid();

        IEnumerable<ValidationError> GetErrors();
    }
}
