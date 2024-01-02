using Microsoft.EntityFrameworkCore;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DBContext dbContext) : base(dbContext) { }

        public async Task<Student> GetStudentByIdIncludingClasses(Guid id)
        {
            return await _dbContext.Set<Student>()
                .Include(s => s.Classes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
