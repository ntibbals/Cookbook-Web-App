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
        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

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

        public async Task<User> GetUser(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.ID == id);
            
            
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
