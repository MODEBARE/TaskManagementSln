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
    public class ProjectRepository: IProjectRepository<Project,int>
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public async Task CreateAsync(Project input)
        {
            _context.Projects.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Project> FirstOrDefaultAsync(Expression<Func<Project, bool>> predicate)
        {
            return await _context.Projects.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public IQueryable<Project> GetAllIncluding(params Expression<Func<Project, object>>[] propertySelectors)
        {
            var query = _context.Projects.AsQueryable();

            foreach (var selector in propertySelectors)
            {
                query = query.Include(selector);
            }

            return query;
        }

        public List<Project> GetAllList(Expression<Func<Project, bool>> predicate)
        {
            return _context.Projects.ToList();
        }

        public async Task<List<Project>> GetAllListAsync(Expression<Func<Project, bool>> predicate)
        {
            return await _context.Projects.Where(predicate).ToListAsync();
        }

        public async Task<Project> GetAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public Task<int> InsertAndGetIdAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Project input)
        {
            _context.Projects.Update(input);
            await _context.SaveChangesAsync();
        }
    }
}
