using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Core.Interfaces
{
    public interface IUserRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task CreateAsync(User input);

        Task UpdateAsync(User input);

        Task DeleteAsync(int id);

        IQueryable<TEntity> GetAll();

        Task<TEntity> GetAsync(TPrimaryKey id);

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);


        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        //Task<TEntity> InsertAsync(TEntity entity);


        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
    }
}
