using Microsoft.EntityFrameworkCore;
using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext) { }

        public async Task<User> Login(string username, string password)
        {
            return await _dbContext.Set<User>()
                .Include(u => u.Student)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
