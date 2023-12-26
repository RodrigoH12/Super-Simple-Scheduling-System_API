using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        void Save();
        IClassRepository ClassRepository { get; }
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
