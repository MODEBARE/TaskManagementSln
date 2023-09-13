using ApplicationShared.Dto.TaskDto;
using ApplicationShared.Dto.UserDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class UserAppService: IUserAppService
    {
        private readonly IUserRepository<User, int> _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository<User, int> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<UserDto> GetUser(int id)
        {
            var User = await _userRepository.GetByIdAsync(id);

            var user = _mapper.Map<UserDto>(User);
            return user;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var user = await _userRepository.GetAllAsync();

            var userDtos = _mapper.Map<List<UserDto>>(user);
            return userDtos;
        }

        public async Task CreateUser(CreateUserInput input)
        {
            // Add any business logic or validation here before saving
            var existingEntity = await _userRepository.FirstOrDefaultAsync(c => c.Name == input.Name);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A user with the same name already exists.");
            }

            var user = _mapper.Map<User>(input);
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateUser(UpdateUserInput input)
        {
            // Add any business logic or validation here before updating

            var user = await _userRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _userRepository.FirstOrDefaultAsync(c => c.Name == input.Name && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A user with the same name already exists.");
            }

            var users = _mapper.Map<User>(input);
            await _userRepository.UpdateAsync(users);
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

