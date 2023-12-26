using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(DBContext dbContext) : base(dbContext) { }
    }
}
