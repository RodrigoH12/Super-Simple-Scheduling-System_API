using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Controllers.Base;

namespace SuperSimpleSchedulingSystem.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : BaseController<UserDto>
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager) : base(userManager)
        {
            _userManager = userManager;
        }
    }
}
