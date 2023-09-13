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
    public class NotificationRepository : INotificationRepository<Notification, int>
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task CreateAsync(Notification input)
        {
            _context.Notifications.Add(input);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification input)
        {
            _context.Notifications.Update(input);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Notification> GetAll()
        {
            return _context.Notifications;
        }

        public async Task<Notification> GetAsync(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(t => t.Id == id);
        }

        public IQueryable<Notification> GetAllIncluding(params Expression<Func<Notification, object>>[] propertySelectors)
        {
            var query = _context.Notifications.AsQueryable();

            foreach (var selector in propertySelectors)
            {
                query = query.Include(selector);
            }

            return query;
        }

        public List<Notification> GetAllList(Expression<Func<Notification, bool>> predicate)
        {
            return _context.Notifications.ToList();
        }

        public async Task<List<Notification>> GetAllListAsync(Expression<Func<Notification, bool>> predicate)
        {
            return await _context.Notifications.Where(predicate).ToListAsync();
        }

        public async Task<Notification> FirstOrDefaultAsync(Expression<Func<Notification, bool>> predicate)
        {
            return await _context.Notifications.FirstOrDefaultAsync(predicate);
        }

        public Task<int> InsertAndGetIdAsync(Notification entity)
        {
            throw new NotImplementedException();
        }
    }

}
