using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class UserService : IUser
    {
        private CookbookDbContext _context { get; }

        public UserService(CookbookDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds user to user talbe
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Task</returns>
        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Removes user from table by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
        public async Task DeleteUser(int id)
        {
            User user = _context.User.FirstOrDefault(u => u.ID == id);
            IEnumerable<SavedRecipe> savedRecipe = _context.SavedRecipe.Where(r => r.UserID == user.ID);
            foreach (var recipe in savedRecipe)
            {
                _context.SavedRecipe.Remove(recipe);
            }
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>user</returns>
        public async Task<User> GetUser(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.ID == id);
            
            
        }
        /// <summary>
        /// Gets IEnumerable of all users in User table
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }
        /// <summary>
        /// Updates user in user table
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Task</returns>
        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
