using Microsoft.EntityFrameworkCore;
using Serilog;
using SuperSimpleSchedulingSystem.Data.Repositories;
using SuperSimpleSchedulingSystem.Data.Repositories.Interfaces;

namespace SuperSimpleSchedulingSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;
        private readonly IClassRepository _class;
        private readonly IStudentRepository _student;
        private readonly IUserRepository _user;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            _class = new ClassRepository(_dbContext);
            _student = new StudentRepository(_dbContext);
            _user = new UserRepository(_dbContext);
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _dbContext.SaveChanges();
                CommitTransaction();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                RollBackTransaction();
                string message = $"Error to save changes on Database -> Save() {Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
                Log.Error(ex, $"{message}{Environment.NewLine} Stack trace: {Environment.NewLine}");
                throw new Exception("Can not save changes, error in Database", ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                RollBackTransaction();
                string message = $"Error to save changes on Database -> Save() {Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
                Log.Error(ex, $"{message}{Environment.NewLine} Stack trace: {Environment.NewLine}");
                throw new Exception("Can not save changes, error in Database", ex.InnerException);
            }
            catch (Exception ex)
            {
                string message = $"Error to save changes on Database -> Save() {Environment.NewLine}Message: {ex.Message}{Environment.NewLine}";
                Log.Error(ex, $"{message}{Environment.NewLine} Stack trace: {Environment.NewLine}");
                throw new Exception("Can not save changes, error in Database", ex.InnerException);
            }
        }

        public IClassRepository ClassRepository => _class;
        public IStudentRepository StudentRepository => _student;
        public IUserRepository UserRepository => _user;
    }
}
