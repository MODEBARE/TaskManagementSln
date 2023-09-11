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

        Task<User> GetUser(int id);
        Task<List<User>> GetAllUsers();
        Task CreateUser(User input);
        Task UpdateUser(User input);
        Task DeleteUser(int id);
    }
}
