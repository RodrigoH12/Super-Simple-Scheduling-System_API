using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;

namespace SuperSimpleSchedulingSystem.Data.Repositories.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<Class> GetClassByIdIncludingStudents(Guid id);
    }
}
