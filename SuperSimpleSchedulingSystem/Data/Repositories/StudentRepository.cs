using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DBContext dbContext) : base(dbContext) { }
    }
}
