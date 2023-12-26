using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Controllers.Base;

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
    }
}
