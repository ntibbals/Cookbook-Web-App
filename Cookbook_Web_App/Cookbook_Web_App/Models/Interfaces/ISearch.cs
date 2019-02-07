using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Interfaces
{
    public interface ISearch 
    {

        Task<Recipe> GetRecipe(int id);

        Task<IEnumerable<Recipe>> GetRecipesAsync();

        Task<SavedRecipe> SaveRecipe(int id, string userName, string name);
    }
}
