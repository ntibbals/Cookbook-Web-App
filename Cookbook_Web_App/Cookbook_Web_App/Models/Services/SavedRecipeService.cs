using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class SavedRecipeService : ISavedRecipe
    {
        private CookbookDbContext _context { get; }

        public SavedRecipeService(CookbookDbContext context)
        {
            _context = context;
        }

        //read
        public async Task <IEnumerable<SavedRecipe>> GetSavedRecipes()
        {
            return await _context.SavedRecipe.ToListAsync();
        }

        public async Task<SavedRecipe> GetSavedRecipe(int? id)
        {
            return await _context.SavedRecipe.FirstOrDefaultAsync(s => s.SavedRecipeID == id);
        }

        //delete
        public async Task DeleteSavedRecipe(int id)
        {
            var comments = await _context.Comments.ToListAsync();
            var userComments = comments.Where(c => c.SavedRecipeID == id);
            foreach (var item in userComments)
            {
                _context.Comments.Remove(item);
            }
            SavedRecipe savedRecipe = _context.SavedRecipe.FirstOrDefault(s => s.SavedRecipeID == id);
            _context.SavedRecipe.Remove(savedRecipe);
            await _context.SaveChangesAsync();
        }
        //confirm existence
        public bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(s => s.SavedRecipeID == id);

        }

        public async Task UpdateSavedRecipe(SavedRecipe savedRecipe)
        {
            _context.SavedRecipe.Update(savedRecipe);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string userName)
        {

            User user = await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

        public async Task CreateRecipe(SavedRecipe recipe)
        {
            _context.SavedRecipe.Add(recipe);
            await _context.SaveChangesAsync();
        }

    }
}
