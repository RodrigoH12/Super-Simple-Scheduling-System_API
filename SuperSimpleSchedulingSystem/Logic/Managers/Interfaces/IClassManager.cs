using SuperSimpleSchedulingSystem.Logic.Managers.Base;
using SuperSimpleSchedulingSystem.Logic.Models;

namespace SuperSimpleSchedulingSystem.Logic.Managers.Interfaces
{
    public interface IClassManager : IGenericManager<ClassDto>
    {
        Task<ClassDto> AssignStudentToClass(Guid classId, Guid studentId);
    }
}
