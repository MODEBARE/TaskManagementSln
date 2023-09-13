using ApplicationShared.Dto.TaskDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Data;
using TaskManagementSystem.Infrastucture.Interfaces;

namespace TaskManagementSystem.Infrastucture.Repositories
{
    public class TaskRepository: ITaskRepository<Tasks, int>
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public async Task CreateAsync(Tasks input)
        {
            _context.Tasks.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tasks> FirstOrDefaultAsync(Expression<Func<Tasks, bool>> predicate)
        {
            return await _context.Tasks.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<Tasks> GetAll()
        {
            return _context.Tasks;
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public IQueryable<Tasks> GetAllIncluding(params Expression<Func<Tasks, object>>[] propertySelectors)
        {
            var query = _context.Tasks.AsQueryable();

            foreach (var selector in propertySelectors)
            {
                query = query.Include(selector);
            }

            return query;
        }

        public List<Tasks> GetAllList(Expression<Func<Tasks, bool>> predicate)
        {
            return _context.Tasks.ToList();
        }

        public async Task<List<Tasks>> GetAllListAsync(Expression<Func<Tasks, bool>> predicate)
        {
            return await _context.Tasks.Where(predicate).ToListAsync();
        }

        public async Task<Tasks> GetAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tasks> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public Task<int> InsertAndGetIdAsync(Tasks entity)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateAsync(Tasks input)
        {
            _context.Tasks.Update(input);
            await _context.SaveChangesAsync();

        }


    }
}
