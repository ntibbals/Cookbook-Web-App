using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Services
{
    public class SearchService : ISearch
    {
        private CookbookDbContext _context { get; }

        public SearchService(CookbookDbContext context)
        {
            _context = context;
        }
        public async Task<Recipe> GetRecipe(int id)
        {
            Recipe recipe = new Recipe();
            IEnumerable<Instructions> instructions = null;
            IEnumerable<RecipeIngredients> recipeIngredients = null;
            IEnumerable<Ingredients> ingredients = null;
            HttpResponseMessage responseRecipe = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Recipes/{id}");
            HttpResponseMessage responseInstructions = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Instructions");
            HttpResponseMessage responseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/RecipeIngredients");
            HttpResponseMessage responseBaseIngredients = await client.GetAsync($"https://cookbookapi20190205105239.azurewebsites.net/api/Ingredients");

            recipe = await responseRecipe.Content.ReadAsAsync<Recipe>();
            instructions = await responseInstructions.Content.ReadAsAsync<IEnumerable<Instructions>>();

            recipeIngredients = await responseIngredients.Content.ReadAsAsync<IEnumerable<RecipeIngredients>>();
            var recipeIngredients2 = recipeIngredients.Where(i => i.recipeID == id);

            ingredients = await responseBaseIngredients.Content.ReadAsAsync<IEnumerable<Ingredients>>();

            foreach (var ing in recipeIngredients2)
            {
                foreach (var item in ingredients)
                {
                    if (item.ID == ing.ingredientsID)
                    {
                        item.Quantity = ing.quantity;
                        item.RecipeID = ing.recipeID;
                    }
                }
            }

            recipe.Ingredients = ingredients.Where(i => i.RecipeID == id);


            recipe.Instructions = instructions.Where(i => i.RecipeId == id);

            return recipe;
        }

        static HttpClient client = new HttpClient();
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            IEnumerable<Recipe> values = null;

            HttpResponseMessage response = await client.GetAsync("https://cookbookapi20190205105239.azurewebsites.net/api/Recipes");
            if (response.IsSuccessStatusCode)
            {
                values = await response.Content.ReadAsAsync<IEnumerable<Recipe>>();
            }

            return values;
        }

        public async Task<SavedRecipe> SaveRecipe(int id, string userName, string name)
        {
            User user = _context.User.FirstOrDefault(u => u.UserName == userName);

            SavedRecipe saveRecipe = new SavedRecipe();
            saveRecipe.UserID = user.ID;
            saveRecipe.APIReference = id;
            saveRecipe.Name = name;

            _context.Add(saveRecipe);
            await _context.SaveChangesAsync();
            return saveRecipe;
        }
    }
}
