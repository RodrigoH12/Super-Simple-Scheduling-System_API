using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Controllers.Base;
using SuperSimpleSchedulingSystem.Presentation.Middleware;

namespace SuperSimpleSchedulingSystem.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/students")]
    public class StudentController : BaseController<StudentDto>
    {
        private readonly IStudentManager _studentManager;

        public StudentController(IStudentManager studentManager) : base(studentManager)
        {
            _studentManager = studentManager;
        }

        /// <summary>
        /// Get a list of all Classes assigned to a Student.
        /// </summary>
        /// <param name="id">Id of the Student.</param>
        /// <returns>The specified Student with the list of Classes assigned.</returns>
        /// <response code="200">Success or some expected Error.</response>
        [HttpGet("{id}/classes")]
        public virtual async Task<IActionResult> GetStudentClasses([FromRoute] Guid id)
        {
            StudentDto response = await _studentManager.GetStudentClasses(id);
            return Ok(new MiddlewareResponse<StudentDto>(response));
        }
    }
}
