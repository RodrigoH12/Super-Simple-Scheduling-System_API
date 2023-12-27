using Microsoft.EntityFrameworkCore;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(DBContext dbContext) : base(dbContext) { }

        public async Task<Class> GetClassByIdIncludingStudents(Guid id)
        {
            return await _dbContext.Set<Class>()
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
