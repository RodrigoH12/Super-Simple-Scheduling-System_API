using SuperSimpleSchedulingSystem.Data.Models;
using SuperSimpleSchedulingSystem.Data.Repositories.Base;

namespace SuperSimpleSchedulingSystem.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string username, string password);
    }
}
