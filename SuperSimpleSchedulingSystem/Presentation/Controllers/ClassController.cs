using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Interfaces;
using SuperSimpleSchedulingSystem.Logic.Models;
using SuperSimpleSchedulingSystem.Presentation.Controllers.Base;

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
    }
}
