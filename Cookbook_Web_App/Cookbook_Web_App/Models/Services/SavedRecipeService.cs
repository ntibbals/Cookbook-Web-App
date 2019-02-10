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

        /// <summary>
        /// Gets list of all saved recipes
        /// </summary>
        /// <returns>Task<IEnumerable<SavedRecipes>>>/All saved recipes</returns>
        public async Task <IEnumerable<SavedRecipe>> GetSavedRecipes()
        {
            return await _context.SavedRecipe.ToListAsync();
        }
        /// <summary>
        /// Gets single saved recipe based on ID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>saved recipe</returns>
        public async Task<SavedRecipe> GetSavedRecipe(int? id)
        {
            return await _context.SavedRecipe.FirstOrDefaultAsync(s => s.SavedRecipeID == id);
        }

        /// <summary>
        /// Removes saved recipe by id from table, and all associated comments
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Task</returns>
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

        /// <summary>
        /// Checks if recipe exists in table by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>bool</returns>
        public bool SavedRecipeExists(int id)
        {
            return _context.SavedRecipe.Any(s => s.SavedRecipeID == id);

        }
        /// <summary>
        /// Updates saved recipe in saved recipe database, not currently ever used.
        /// </summary>
        /// <param name="savedRecipe">Savedrecipe</param>
        /// <returns>Task</returns>
        public async Task UpdateSavedRecipe(SavedRecipe savedRecipe)
        {
            _context.SavedRecipe.Update(savedRecipe);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets user
        /// </summary>
        /// <param name="userName">string</param>
        /// <returns>user</returns>
        public async Task<User> GetUser(string userName)
        {

            User user = await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }
        /// <summary>
        /// Saved recipe from API to table
        /// </summary>
        /// <param name="recipe">SavedRecipe</param>
        /// <returns>Task</returns>
        public async Task CreateRecipe(SavedRecipe recipe)
        {
            _context.SavedRecipe.Add(recipe);
            await _context.SaveChangesAsync();
        }

    }
}
