using SuperSimpleSchedulingSystem.Logic.Models;

namespace SuperSimpleSchedulingSystem.Logic.Managers.Interfaces
{
    public interface ILoginManager
    {
        Task<UserDto> Login(string username, string password);
    }
}
