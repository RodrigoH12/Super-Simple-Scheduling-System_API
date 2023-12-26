using SuperSimpleSchedulingSystem.Data.Models.Base;

namespace SuperSimpleSchedulingSystem.Data.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
