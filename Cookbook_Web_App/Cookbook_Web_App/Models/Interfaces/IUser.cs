using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Interfaces
{
    public interface IUser
    {
        Task CreateUser(User user);

        Task<User> GetUser(int id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task UpdateUser(User user);

        Task DeleteUser(int id);
    }
}
