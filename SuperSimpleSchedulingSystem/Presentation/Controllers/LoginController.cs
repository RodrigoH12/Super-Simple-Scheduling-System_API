using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Middleware;

namespace SuperSimpleSchedulingSystem.Presentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginManager _loginManager;

        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        /// <summary>
        /// Log in with a username and password.
        /// </summary>
        /// <param name="username">username of the User</param>
        /// <param name="password">password of the User</param>
        /// <returns>The User that was logged in.</returns>
        /// <response code="200">Success or some expected Error.</response>
        [HttpGet("username/{username}/password/{password}")]
        public virtual async Task<IActionResult> GetStudentsInAClass([FromRoute] string username, [FromRoute] string password)
        {
            UserDto response = await _loginManager.Login(username, password);
            return Ok(new MiddlewareResponse<UserDto>(response));
        }
    }
}
