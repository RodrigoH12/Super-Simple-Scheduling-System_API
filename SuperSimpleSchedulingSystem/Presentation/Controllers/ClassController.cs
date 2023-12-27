using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Controllers.Base;
using SuperSimpleSchedulingSystem.Presentation.Middleware;
using System.Net;

namespace SuperSimpleSchedulingSystem.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/classes")]
    public class ClassController : BaseController<ClassDto>
    {
        private readonly IClassManager _classManager;

        public ClassController(IClassManager classManager) : base(classManager)
        {
            _classManager = classManager;
        }

        /// <summary>
        /// Assign a Student into a specific Class.
        /// </summary>
        /// <param name="classId">Id of the Class.</param>
        /// <param name="studentId">Id of the Student.</param>
        /// <returns>The specified Class with the list of Students assigned.</returns>
        /// <response code="200">Success or some expected Error.</response>
        [HttpPut("{classId}/students/{studentId}")]
        public virtual async Task<IActionResult> AssignStudentToClass([FromRoute] Guid classId, [FromRoute] Guid studentId)
        {
            ClassDto response = await _classManager.AssignStudentToClass(classId, studentId);
            return Ok(new MiddlewareResponse<ClassDto>(response));
        }
    }
}
