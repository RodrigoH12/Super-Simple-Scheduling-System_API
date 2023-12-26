using Microsoft.EntityFrameworkCore;
using SuperSimpleSchedulingSystem.Data.Exceptions;
using SuperSimpleSchedulingSystem.Data.Models.Base;

namespace SuperSimpleSchedulingSystem.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DBContext _dbContext;

        public Repository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> values = await _dbContext.Set<T>()
                .ToListAsync();
            return values;
        }

        public async Task<T> GetById(Guid id)
        {
            T value = await _dbContext.Set<T>()
                .FindAsync(id);
            return value;
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                entity.Id = Guid.Empty;
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error while trying to create entity of type {typeof(T).Name}", e.InnerException);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error while trying to update entity of type {typeof(T).Name}", e.InnerException);
            }
        }

        public async Task<T> Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new DatabaseException($"Error while trying to delete entity of type {typeof(T).Name}", e.InnerException);
            }
        }
    }
}
