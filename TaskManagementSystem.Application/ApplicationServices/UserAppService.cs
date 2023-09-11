using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class UserAppService: IUserAppService
    {
        private readonly IUserRepository<User, int> _userRepository;

        public UserAppService(IUserRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task CreateUser(User user)
        {
            // Add any business logic or validation here before saving
            var existingEntity = await _userRepository.FirstOrDefaultAsync(c => c.Name == user.Name);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A user with the same name already exists.");
            }
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUser(User input)
        {
            // Add any business logic or validation here before updating

            var user = await _userRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _userRepository.FirstOrDefaultAsync(c => c.Name == input.Name && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A user with the same name already exists.");
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            // Add any business logic or validation here before deleting
            var existingEntity = await _userRepository.FirstOrDefaultAsync(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("A user with Id not exists.");
            }

            await _userRepository.DeleteAsync(id);
        }
    }       
    
    }

