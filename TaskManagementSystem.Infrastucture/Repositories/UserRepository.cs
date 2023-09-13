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
    public class UserRepository: IUserRepository<User, int>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
                _context = context;
        }

        public async Task CreateAsync(User input)
        {
            _context.Users.Add(input);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public IQueryable<User> GetAllIncluding(params Expression<Func<User, object>>[] propertySelectors)
        {
            var query = _context.Users.AsQueryable();

            foreach (var selector in propertySelectors)
            {
                query = query.Include(selector);
            }

            return query;
        }

        public List<User> GetAllList(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.ToList();
        }

        public async Task<List<User>> GetAllListAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<int> InsertAndGetIdAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User input)
        {
            _context.Users.Update(input);
            await _context.SaveChangesAsync();
        }


    }
}
