using ApplicationShared.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.IApplicationServices
{
    public interface IUserAppService
    {

        Task<UserDto> GetUser(int id);
        Task<List<UserDto>> GetAllUsers();
        Task CreateUser(CreateUserInput input);
        Task UpdateUser(UpdateUserInput input);
        Task DeleteUser(int id);
    }
}
