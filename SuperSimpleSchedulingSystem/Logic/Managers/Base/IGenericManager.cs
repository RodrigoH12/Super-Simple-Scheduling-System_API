namespace SuperSimpleSchedulingSystem.Logic.Managers.Base
{
    public interface IGenericManager<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T item);

        Task<T> Update(Guid id, T item);

        Task<bool> Delete(Guid itemId);
    }
}
